//
//  AboutViewController.swift
//  APUSH Companion
//
//  Created by Adeem on 1/31/19.
//  Copyright © 2019 Adeem. All rights reserved.
//

import UIKit
import StoreKit
import GoogleMobileAds

class AboutViewController: UIViewController, SKProductsRequestDelegate, SKPaymentTransactionObserver, SideMenuItemContent, Storyboardable {

    @IBOutlet weak var removeAdsButton: UIButton!
    @IBOutlet weak var restorePurchaseButton: UIButton!
    @IBOutlet weak var bannerView: GADBannerView!
    
    private let iapProductID = "removeAdsAPUSH"
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        SKPaymentQueue.default().add(self)
        
        designButtons()
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

    @IBAction func openMenu(_ sender: Any) {
        showSideMenu()
    }
    
    @IBAction func removeAdsClicked(_ sender: Any) {
        if (SKPaymentQueue.canMakePayments())
        {
            let productID = NSSet(object: iapProductID)
            let productsRequest:SKProductsRequest = SKProductsRequest(productIdentifiers: productID as! Set<String>)
            productsRequest.delegate = self
            productsRequest.start()
        }
    }
    
    @IBAction func restorePurchaseClicked(_ sender: Any) {
        if (SKPaymentQueue.canMakePayments()) {
            SKPaymentQueue.default().restoreCompletedTransactions()
        }
    }
    
    func buyProduct(product: SKProduct){
        let payment = SKPayment(product: product)
        SKPaymentQueue.default().add(payment)
    }
    
    func productsRequest(_ request: SKProductsRequest, didReceive response: SKProductsResponse) {
        if (response.products.count > 0) {
            let validProduct: SKProduct = response.products[0] as SKProduct
            
            if (validProduct.productIdentifier == self.iapProductID) {
                buyProduct(product: validProduct)
            }
        }
    }
    
    func paymentQueue(_ queue: SKPaymentQueue, updatedTransactions transactions: [SKPaymentTransaction]) {
        for transaction:AnyObject in transactions {
            if let trans:SKPaymentTransaction = transaction as? SKPaymentTransaction{
                switch trans.transactionState {
                case .purchased:
                    SKPaymentQueue.default().finishTransaction(transaction as! SKPaymentTransaction)
                    UserDefaults.standard.set(true , forKey: "removeAds")
                    break;
                    
                case .failed:
                    SKPaymentQueue.default().finishTransaction(transaction as! SKPaymentTransaction)
                    break;
                    
                case .restored:
                    SKPaymentQueue.default().restoreCompletedTransactions()
                    UserDefaults.standard.set(true , forKey: "removeAds")
                    break;
                    
                default:
                    break;
                }
            }
        }
    }
    
    func designButtons() {
        removeAdsButton.layer.cornerRadius = 3
        removeAdsButton.layer.borderWidth = 1
        removeAdsButton.layer.borderColor = UIColor.darkText.cgColor
        removeAdsButton.titleEdgeInsets = UIEdgeInsets(top: 5, left: 5, bottom: 5, right: 5)
        
        restorePurchaseButton.layer.cornerRadius = 5
        restorePurchaseButton.layer.borderWidth = 1
        restorePurchaseButton.layer.borderColor = UIColor.darkText.cgColor
        restorePurchaseButton.titleEdgeInsets = UIEdgeInsets(top: 5, left: 5, bottom: 5, right: 5)
    }
}
