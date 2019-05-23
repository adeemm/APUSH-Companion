//
//  PDFPageViewController.swift
//  APUSH Companion
//
//  Created by Adeem on 1/30/19.
//  Copyright © 2019 Adeem. All rights reserved.
//

import UIKit
import GoogleMobileAds

class PDFPageViewController: UIViewController {
    
    @IBOutlet weak var webView: UIWebView!
    @IBOutlet weak var bannerView: GADBannerView!

    var pdfName: String?
    var docTitle: String?
    
    override func viewDidLoad() {
        super.viewDidLoad()
        title = docTitle
        loadAds()
        
        if let url = Bundle.main.url(forResource: pdfName, withExtension: "pdf") {
            webView.loadRequest(URLRequest(url: url))
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
}
