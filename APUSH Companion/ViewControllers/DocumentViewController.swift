//
//  DocumentViewController.swift
//  APUSH Companion
//
//  Created by Adeem on 1/30/19.
//  Copyright © 2019 Adeem. All rights reserved.
//

import UIKit

class DocumentViewController: UITableViewController, SideMenuItemContent, Storyboardable {
    
    private var selectedDocTitle: String?
    private var selectedPDFName: String?
    
    override func viewDidLoad() {
        super.viewDidLoad()
    }
    
    @IBAction func openMenu(_ sender: Any) {
        showSideMenu()
    }
    
    override func tableView(_ tableView: UITableView, didSelectRowAt indexPath: IndexPath) {
        handleCellClick(indexPath: indexPath)
    }
    
    func handleCellClick(indexPath: IndexPath) {
        switch indexPath.section {
            case 0:
                (indexPath.row == 0) ? (selectedPDFName = "S1Outline") : (selectedPDFName = "S2Outline")
                break
            
            case 1:
                if (indexPath.row == 0) { selectedPDFName = "CollectiveOutline" }
                else if (indexPath.row == 1) { selectedPDFName = "ReviewPacket" }
                else { selectedPDFName = "Presidents" }
                break
            
            case 2:
                selectedPDFName = "ch" + String(indexPath.row + 1)
                break
            
            default:
                break
        }
        
        selectedDocTitle = tableView.cellForRow(at: indexPath)?.textLabel?.text
        self.performSegue(withIdentifier: "pdfSegue", sender: self)
    }
    
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        let backButtonItem = UIBarButtonItem()
        backButtonItem.title = "Back"
        navigationItem.backBarButtonItem = backButtonItem
        
        if segue.identifier == "pdfSegue" {
            let pdfVC = segue.destination as! PDFPageViewController
            pdfVC.docTitle = selectedDocTitle
            pdfVC.pdfName = selectedPDFName
        }
    }
}
