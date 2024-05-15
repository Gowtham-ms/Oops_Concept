// component decorator mention to angular as this is a component
import { Component } from "@angular/core";

@Component({
    selector: 'app-hello-world',
    // template: "<h1>Test</h1>",
    templateUrl: "./hello-world.component.html",
    // styles: "h1 {color: red}"
    styleUrls: ["./hello-world.component.css"]
})

export class HelloWorldComponent {
    // property inside the class
    title = 'hello world works'
}