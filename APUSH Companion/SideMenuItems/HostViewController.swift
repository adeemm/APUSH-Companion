//
//  HostViewController.swift
//  APUSH Companion
//
//  Created by Adeem on 1/27/19.
//  Copyright © 2019 Adeem. All rights reserved.
//

import UIKit

class HostViewController: MenuContainerViewController {
    
    override var prefersStatusBarHidden: Bool {
        return false
    }
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        let screenSize: CGRect = UIScreen.main.bounds
        self.transitionOptions = TransitionOptions(duration: 0.4, visibleContentWidth: screenSize.width / 6)

        self.menuViewController = SideMenuViewController.storyboardViewController()

        self.contentViewControllers = contentControllers()

        self.selectContentViewController(contentViewControllers.first!)
        
        self.currentItemOptions.cornerRadius = 10.0
    }
    
    override func viewWillTransition(to size: CGSize, with coordinator: UIViewControllerTransitionCoordinator) {
        super.viewWillTransition(to: size, with: coordinator)

        var options = TransitionOptions()
        options.duration = size.width < size.height ? 0.4 : 0.6
        options.visibleContentWidth = size.width / 6
        
        self.transitionOptions = options
    }
    
    private func contentControllers() -> [UIViewController] {
        let homeController = HomeViewController.storyboardNavigationController()
        let vocabController = VocabViewController.storyboardNavigationController()
        let flashCardController = FlashCardViewController.storyboardNavigationController()
        let documentController = DocumentViewController.storyboardNavigationController()
        let videoController = VideoViewController.storyboardNavigationController()
        let aboutController = AboutViewController.storyboardNavigationController()
        
        return [homeController, vocabController, flashCardController, documentController, videoController, aboutController]
    }
}
