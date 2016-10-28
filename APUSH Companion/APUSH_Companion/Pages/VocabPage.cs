using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using Xamarin.Forms;

namespace APUSH_Companion.Pages
{
    public class VocabPage : ContentPage
    {
        public VocabPage()
        {
            Title = "Vocabulary & ID's";
            Icon = "vocab.png";

            var dataTemplate = new DataTemplate(typeof(TextCell));
            dataTemplate.SetBinding(TextCell.TextProperty, "Term");
            dataTemplate.SetBinding(TextCell.DetailProperty, "Def");

            var vocabTerms = Models.Vocab.PopulateVocab();

            SearchBar searchbar = new SearchBar()
            {
                Placeholder = "Search"
            };

            var listView = new ListView(ListViewCachingStrategy.RecycleElement)
            {
                HasUnevenRows = true,
                IsGroupingEnabled = true,
                GroupDisplayBinding = new Binding("Name"),
                GroupShortNameBinding = new Binding("Name"),
                ItemsSource = vocabTerms,
                ItemTemplate = dataTemplate
            };

            listView.ItemSelected += (object sender, SelectedItemChangedEventArgs e) =>
            {
                if (e.SelectedItem != null)
                {
                    var selected = e.SelectedItem as Models.Vocab;
                    Navigation.PushAsync(new VocabEntryPage(selected.Term, selected.Def));
                    ((ListView)sender).SelectedItem = null;
                }
            };

            searchbar.TextChanged += (sender, e) =>
            {
                var final = new ObservableCollection<Models.GrouppedVocab>();
                final.Clear();

                listView.BeginRefresh();

                if (!string.IsNullOrWhiteSpace(e.NewTextValue)) 
                {
                    foreach (var group in vocabTerms)
                    {
                        foreach (var term in group)
                        {
                            if (term.Term.ToLower().Contains(e.NewTextValue.ToLower()))
                            {
                                if (final.Any(x => x.Name == term.Key))
                                {
                                    var collection = final.Where(x => (x.Name == term.Key));
                                    collection.ElementAt(0).Add(term);
                                }
                                else
                                {
                                    var newCollection = new Models.GrouppedVocab(term.Key);
                                    newCollection.Add(term);
                                    final.Add(newCollection);
                                }
                            }
                        }
                    }

                    listView.ItemsSource = final; //vocabTerms.Where(x => x.Any(y => y.Term.ToLower().Contains(e.NewTextValue.ToLower()))); <- cleaner but isnt good enough
                }
                else
                    listView.ItemsSource = vocabTerms;

                listView.EndRefresh();
            };

            Content = new StackLayout { Children = { searchbar, listView } };
        }
    }
}
