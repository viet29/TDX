import { Component, OnInit } from '@angular/core';
import { TabDirective } from 'ngx-bootstrap/tabs';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent implements OnInit {

  selectedTab: string = "Người dùng";

  ngOnInit(): void {

  }

  oonSelectTab(tabData: TabDirective) {
    const currentTab = tabData.heading!;
    if (currentTab === 'Người dùng') {
      this.selectedTab = tabData.heading!;
    }
  }
}
