//
//  VocabDetailViewController.swift
//  APUSH Companion
//
//  Created by Adeem on 1/27/19.
//  Copyright © 2019 Adeem. All rights reserved.
//

import UIKit

class VocabDetailViewController: UIViewController {

    @IBOutlet weak var titleLabel: UILabel!
    @IBOutlet weak var descLabel: UILabel!
    
    var vocabWord: String?
    var vocabDef: String?
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        titleLabel.text = vocabWord
        descLabel.text = vocabDef
    }

}
