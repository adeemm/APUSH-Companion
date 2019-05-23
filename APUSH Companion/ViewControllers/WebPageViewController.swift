//
//  WebPageViewController.swift
//  APUSH Companion
//
//  Created by Adeem on 1/31/19.
//  Copyright © 2019 Adeem. All rights reserved.
//

import UIKit
import GoogleMobileAds

class WebPageViewController: UIViewController, UIWebViewDelegate {

    @IBOutlet weak var webView: UIWebView!
    @IBOutlet weak var bannerView: GADBannerView!
    
    var webAddress: String?
    var videoTitle: String?
    private var indicator: UIActivityIndicatorView?
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        loadAds()
        
        webView.delegate = self
        indicator = showActivityIndicatory(uiView: self.view)
        
        title = videoTitle
        
        if let address = webAddress {
            if let url = URL(string: address) {
                webView.loadRequest(URLRequest(url: url))
            }
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

    func webViewDidFinishLoad(_ webView: UIWebView) {
        indicator?.stopAnimating()
        indicator?.superview?.superview?.removeFromSuperview()
    }
    
    func showActivityIndicatory(uiView: UIView) -> UIActivityIndicatorView {
        uiView.endEditing(true)
        
        let container: UIView = UIView()
        container.frame = uiView.frame
        container.center = uiView.center
        container.backgroundColor = UIColor(red: 1.0, green: 1.0, blue: 1.0, alpha: 0.3)
        
        let loadingView: UIView = UIView()
        loadingView.frame = CGRect(origin: CGPoint(x: 0, y: 0), size: CGSize(width: 80, height: 80))
        loadingView.center = CGPoint(x: uiView.center.x, y: uiView.center.y)
        loadingView.backgroundColor = UIColor(red: 68/255, green: 68/255, blue: 68/255, alpha: 0.7)
        loadingView.clipsToBounds = true
        loadingView.layer.cornerRadius = 10
        
        let activityIndicator: UIActivityIndicatorView = UIActivityIndicatorView()
        activityIndicator.frame = CGRect(origin: CGPoint(x: 0, y: 0), size: CGSize(width: 40, height: 40))
        activityIndicator.style = UIActivityIndicatorView.Style.whiteLarge
        activityIndicator.center = CGPoint(x: loadingView.frame.size.width / 2, y: loadingView.frame.size.height / 2)
        
        loadingView.addSubview(activityIndicator)
        container.addSubview(loadingView)
        uiView.addSubview(container)
        activityIndicator.startAnimating()
        
        return activityIndicator
    }
}
