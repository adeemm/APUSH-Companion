//
//  VideoViewController.swift
//  APUSH Companion
//
//  Created by Adeem on 1/31/19.
//  Copyright © 2019 Adeem. All rights reserved.
//

import UIKit
import GoogleMobileAds

class VideoViewController: UITableViewController, GADInterstitialDelegate, SideMenuItemContent, Storyboardable {

    private var selectedVideo: String?
    private var webAddress: String?
    private var interstitial: GADInterstitial!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        loadAds()
    }
    
    @IBAction func openMenu(_ sender: Any) {
        showSideMenu()
    }
    
    func loadAds() {
        if (!UserDefaults.standard.bool(forKey: "removeAds")) {
            interstitial = reloadInterstitial()
        }
    }
    
    func reloadInterstitial() -> GADInterstitial {
        let interstitial = GADInterstitial(adUnitID: "REDACTED")
        interstitial.delegate = self
        interstitial.load(GADRequest())
        return interstitial
    }
    
    func interstitialDidDismissScreen(_ ad: GADInterstitial) {
        if (!UserDefaults.standard.bool(forKey: "removeAds")) {
            interstitial = reloadInterstitial()
        }
    }
    
    override func tableView(_ tableView: UITableView, didSelectRowAt indexPath: IndexPath) {
        switch indexPath.row {
            case 0:
                webAddress = "https://www.youtube.com/playlist?list=PL8dPuuaLjXtMwmepBjTSG593eG7ObzO7s"
                selectedVideo = "Crash Course"
                break
            
            case 2:
                webAddress = "https://www.youtube.com/channel/UC223Rd7yCfDo9fv6ENdNp9Q/videos"
                selectedVideo = "Adam Norris"
                break
            
            case 4:
                webAddress = "https://www.youtube.com/user/JoczProductions/videos?sort=p"
                selectedVideo = "JoczProductions"
                break
            
            case 6:
                webAddress = "https://www.khanacademy.org/humanities/us-history"
                selectedVideo = "Khan Academy"
                break
            
            case 8:
                webAddress = "https://ap.gilderlehrman.org/"
                selectedVideo = "Gilder Lehrman"
                break
            
            case 10:
                webAddress = "https://www.youtube.com/playlist?list=PLfzs_X6OQBOy2rs4mrV2O9t3vNB4RF_Es"
                selectedVideo = "Tom Richey"
                break
        
            default:
                break
        }
        
        self.performSegue(withIdentifier: "webSegue", sender: self)
    }
    
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        let backButtonItem = UIBarButtonItem()
        backButtonItem.title = "Back"
        navigationItem.backBarButtonItem = backButtonItem
        
        if (interstitial.isReady && !UserDefaults.standard.bool(forKey: "removeAds")) {
            interstitial.present(fromRootViewController: self)
        }
        
        if segue.identifier == "webSegue" {
            let webVC = segue.destination as! WebPageViewController
            webVC.videoTitle = selectedVideo
            webVC.webAddress = webAddress
        }
    }
}
