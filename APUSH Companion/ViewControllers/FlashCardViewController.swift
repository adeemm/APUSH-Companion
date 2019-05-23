//
//  FlashCardViewController.swift
//  APUSH Companion
//
//  Created by Adeem on 1/26/19.
//  Copyright © 2019 Adeem. All rights reserved.
//

import UIKit
import GoogleMobileAds

class FlashCardViewController: UIViewController, SideMenuItemContent, Storyboardable {
    
    @IBOutlet weak var card: UIView!
    @IBOutlet weak var backLabel: UILabel!
    @IBOutlet weak var frontLabel: UILabel!
    @IBOutlet weak var flipCardButton: UIButton!
    @IBOutlet weak var randomizeButton: UIButton!
    @IBOutlet weak var resetButton: UIButton!
    @IBOutlet weak var nextButton: UIButton!
    @IBOutlet weak var prevButton: UIButton!
    @IBOutlet weak var bannerView: GADBannerView!
    
    private var vocabList = [Vocab]()
    private var currentIndex = 0

    override func viewDidLoad() {
        super.viewDidLoad()
        
        initializeThings()
        updateLabels()
        updateNextPrevButtons()
        loadAds()
    }
    
    override func viewWillAppear(_ animated: Bool) {
        if (UserDefaults.standard.bool(forKey: "removeAds")) {
            bannerView.isHidden = true
        }
    }
    
    func loadAds() {
        if (UserDefaults.standard.bool(forKey: "removeAds")) {
            bannerView.isHidden = true
        }
        else {
            bannerView.adUnitID = "REDACTED"
            bannerView.rootViewController = self
            bannerView.adSize = kGADAdSizeSmartBannerPortrait
            bannerView.load(GADRequest())
        }
    }
    
    @IBAction func openMenu(_ sender: UIButton) {
        showSideMenu()
    }
    
    @IBAction func didTapOnFlashcard(_ sender: Any) {
        handleFlip()
    }
    
    @IBAction func flipButtonClicked(_ sender: Any) {
        handleFlip()
    }
    
    @IBAction func randomizeButtonClicked(_ sender: Any) {
        vocabList.shuffle()
        currentIndex = 0
        updateLabels()
        updateNextPrevButtons()
    }
    
    @IBAction func resetButtonClicked(_ sender: Any) {
        currentIndex = 0
        updateLabels()
        updateNextPrevButtons()
    }
    
    @IBAction func didTapOnNext(_ sender: Any) {
        currentIndex = currentIndex + 1
        updateNextPrevButtons()
        animateCardOut()
    }
    
    @IBAction func didTapOnPrev(_ sender: Any) {
        currentIndex = currentIndex - 1
        updateNextPrevButtons()
        prevAnimateCardOut()
    }
    
    func handleFlip() {
        frontLabel.isHidden ? flipFlashcardBack() : flipFlashcard()
    }
    
    func updateLabels() {
        let currentFlashcard = vocabList[currentIndex]
        
        frontLabel.text = currentFlashcard.term
        backLabel.text = currentFlashcard.definition
    }
    
    func flipFlashcard() {
        backLabel.isHidden = false
        UIView.transition(with: card, duration: 0.3, options: .transitionFlipFromRight, animations: {
            self.frontLabel.isHidden = true
        })
    }
    
    func flipFlashcardBack() {
        frontLabel.isHidden = false
        UIView.transition(with: card, duration: 0.3, options: .transitionFlipFromLeft, animations: {
            self.backLabel.isHidden = true
        })
    }
    
    func animateCardOut() {
        UIView.animate(withDuration: 0.3, animations: {
            self.card.transform = CGAffineTransform.identity.translatedBy(x: -300, y: 0.0)
        }, completion: { finished in
            self.updateLabels()
            self.animateCardIn()
        })
    }
    
    func animateCardIn() {
        card.transform = CGAffineTransform.identity.translatedBy(x: 300, y: 0.0)

        UIView.animate(withDuration: 0.3) {
            self.card.transform = CGAffineTransform.identity
        }
    }
    
    func prevAnimateCardOut() {
        UIView.animate(withDuration: 0.3, animations: {
            self.card.transform = CGAffineTransform.identity.translatedBy(x: 300, y: 0.0)
        }, completion: { finished in
            self.updateLabels()
            self.prevAnimateCardIn()
        })
    }
    
    func prevAnimateCardIn() {
        card.transform = CGAffineTransform.identity.translatedBy(x: -300, y: 0.0)
        
        UIView.animate(withDuration: 0.3) {
            self.card.transform = CGAffineTransform.identity
        }
    }
    
    func updateNextPrevButtons() {
        if (currentIndex == (vocabList.count - 1)) {
            nextButton.isEnabled = false
        }
        else {
            nextButton.isEnabled = true
        }

        if (currentIndex == 0) {
            prevButton.isEnabled = false
        }
        else {
            prevButton.isEnabled = true
        }
    }
    
    func initializeThings() {
        // Convert grouped vocab into simple Vocab array for easier axis
        let vocabGroups = Vocab.getVocabList()
        for group in vocabGroups {
            vocabList.append(contentsOf: group.vocabList)
        }
    }
}
