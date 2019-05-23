//
//  VocabViewController.swift
//  APUSH Companion
//
//  Created by Adeem on 1/26/19.
//  Copyright © 2019 Adeem. All rights reserved.
//

import UIKit

class VocabViewController: UITableViewController, UISearchResultsUpdating, SideMenuItemContent, Storyboardable {
    
    @IBOutlet var vocabTableView: UITableView!

    private var selectedVocab: Vocab?
    private var vocabKeys = [String]()
    private var tableDict = [String:[Vocab]]()
    private var filteredTableData = [String:[Vocab]]()
    private var searchController = UISearchController()
    
    // Color cached to improve performance
    private var grayColor = UIColor.gray
    
    override func viewDidLoad() {
        super.viewDidLoad()
        setupTable()
    }
    
    @IBAction func openMenu(_ sender: Any) {
        showSideMenu()
    }
    
    func setupTable() {
        searchController = ({
            let controller = UISearchController(searchResultsController: nil)
            controller.searchResultsUpdater = self
            controller.dimsBackgroundDuringPresentation = false
            controller.searchBar.sizeToFit()
            
            vocabTableView.tableHeaderView = controller.searchBar
            
            return controller
        })()
        
        let vocabGroups = Vocab.getVocabList()
        for group in vocabGroups {
            tableDict[group.key] = group.vocabList
        }
        vocabKeys = [String](tableDict.keys)
        vocabKeys = vocabKeys.sorted(by: { $0 < $1 })
        
        vocabTableView.reloadData()
    }
    
    override func numberOfSections(in tableView: UITableView) -> Int {
        return vocabKeys.count
    }
    
    override func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        let currentSection = vocabKeys[section]

        if searchController.isActive {
            return filteredTableData[currentSection]?.count ?? 0
        }
        else {
            return tableDict[currentSection]?.count ?? 0
        }
    }
    
    override func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "VocabCell", for: indexPath)
        
        let key = vocabKeys[indexPath.section]
        var vocab: [Vocab]?
        
        searchController.isActive ? (vocab = filteredTableData[key]) : (vocab = tableDict[key])
        
        if let vocabCells = vocab {
            cell.textLabel?.text = vocabCells[indexPath.row].term
            cell.detailTextLabel?.text = vocabCells[indexPath.row].definition
            cell.detailTextLabel?.textColor = grayColor
        }
        
        return cell
    }
    
    override func tableView(_ tableView: UITableView, titleForHeaderInSection section: Int) -> String? {
        if (self.tableView(tableView, numberOfRowsInSection: section) > 0) {
            return vocabKeys[section]
        }
        else {
            return nil
        }
    }
    
    override func sectionIndexTitles(for tableView: UITableView) -> [String]? {
        if searchController.isActive {
            return [String](filteredTableData.keys).sorted(by: { $0 < $1 })
        }
        else {
            return vocabKeys
        }
    }
    
    override func tableView(_ tableView: UITableView, didSelectRowAt indexPath: IndexPath) {
        let key = vocabKeys[indexPath.section]
        
        if searchController.isActive {
            if let vocab = filteredTableData[key] {
                selectedVocab = vocab[indexPath.row]
                searchController.dismiss(animated: false, completion: nil)
                self.performSegue(withIdentifier: "detailSegue", sender: self)
            }
        }
        else {
            if let vocab = tableDict[key] {
                selectedVocab = vocab[indexPath.row]
                searchController.dismiss(animated: false, completion: nil)
                self.performSegue(withIdentifier: "detailSegue", sender: self)
            }
        }
    }
    
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        let backButtonItem = UIBarButtonItem()
        backButtonItem.title = "Back"
        navigationItem.backBarButtonItem = backButtonItem
        
        if segue.identifier == "detailSegue" {
            let detailVC = segue.destination as! VocabDetailViewController
            detailVC.vocabWord = selectedVocab?.term
            detailVC.vocabDef = selectedVocab?.definition
        }
    }
    
    func updateSearchResults(for searchController: UISearchController) {
        filteredTableData.removeAll()

        let searchText = searchController.searchBar.text!.lowercased()
        filteredTableData = tableDict.mapValues { $0.filter { $0.term.lowercased().contains(searchText) } }.filter { !$0.value.isEmpty }
        
        self.vocabTableView.reloadData()
    }
}

