//
//  HomeViewController.swift
//  APUSH Companion
//
//  Created by Adeem on 1/26/19.
//  Copyright © 2019 Adeem. All rights reserved.
//

import UIKit
import GoogleMobileAds

class HomeViewController: UIViewController, SideMenuItemContent, Storyboardable {
    
    @IBOutlet weak var bannerView: GADBannerView!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        setNeedsStatusBarAppearanceUpdate()
        loadAds()
    }
    
    override func viewWillAppear(_ animated: Bool) {
        if (UserDefaults.standard.bool(forKey: "removeAds")) {
            bannerView.isHidden = true
        }
    }
    
    @IBAction func openMenu(_ sender: UIButton) {
        showSideMenu()
    }
    
    override var preferredStatusBarStyle: UIStatusBarStyle {
        return .default
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
}

