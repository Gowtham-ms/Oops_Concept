import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrl: './my-profile.component.css'
})
export class MyProfileComponent implements OnInit {
  user: { name: string } = { name: '' };
  // // activated route get the current route ID (which is going to be unique)
  constructor(private myRoute: ActivatedRoute) { }
  ngOnInit(): void {
    this.user = {
      name: this.myRoute.snapshot.params['name']
    }
  }
}
