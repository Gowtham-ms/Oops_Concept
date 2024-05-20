import { Component } from '@angular/core';

@Component({
  selector: 'app-hello-world',
  templateUrl: './hello-world.component.html',
  styleUrl: './hello-world.component.css'
})
export class HelloWorldComponent {
  // firstName = 'Sachin'
  // lastName = 'Tendulkar'
  // // property
  // title = "Learning Angular"
  // isDisabled: boolean = false;
  // // name = 'test'

  // getTitle() {
  //   return this.title;
  // }

  // getMax(first: number, second: number) {
  //   return Math.max(first, second);
  // }
  // clickCount = 0;
  // clickCount1 = 0;
  // onSubmit(count: number) {
  //   alert(count);
  //   this.clickCount++;
  //   this.clickCount1 = this.clickCount;
  // }
  // value = ''
  // value1 =''
  // handleInput(event: any) {
  //   this.value = (event.target as HTMLInputElement).value;
  // }

  title="List of Movies"
  movies=[
    {title:'Batman', director:'someone'},
    {title:'Spiderman', director:'spiderman director'},
    {title:'Superman', director:'Superman director'},
    {title:'Amazing Spiderman', director:'Amazing Spiderman director'}
    // 'Batman',
    // 'Spiderman',
    // 'Superman',
    // 'x-Men',
    // 'Amazing Spiderman'
  ]
}
