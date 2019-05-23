//
//  SampleTableCell.swift
//  APUSH Companion
//
//  Created by Adeem on 1/27/19.
//  Copyright © 2019 Adeem. All rights reserved.
//

import UIKit

class TableCell: UITableViewCell {

    @IBOutlet weak var titleLabel: UILabel!
    @IBOutlet private weak var selectedView: UIView!
    
    let selectedColor = UIColor(red:0.88, green:0.31, blue:0.35, alpha:1.0)
    let boldFont = UIFont.boldSystemFont(ofSize: 18)
    let regularFont = UIFont.systemFont(ofSize: 17)
    
    override func awakeFromNib() {
        super.awakeFromNib()
        
        selectionStyle = .none
    }

    override func setSelected(_ selected: Bool, animated: Bool) {
        super.setSelected(selected, animated: animated)

        selectedView.backgroundColor = selected ? selectedColor : UIColor.clear
        titleLabel.textColor = selected ? selectedColor : UIColor.white
        titleLabel.font = selected ? boldFont : regularFont
    }
}
