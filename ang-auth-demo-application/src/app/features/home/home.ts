import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  imports: [],
  templateUrl: './home.html',
  styleUrl: './home.scss',
})
export class Home implements OnInit {
  

  ngOnInit(): void {
    //throw new Error('Method not implemented.');
    console.log('Data loaded.')
  }
}
