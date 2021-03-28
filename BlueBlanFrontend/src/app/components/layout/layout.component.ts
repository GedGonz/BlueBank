import { Component, OnInit, ElementRef, Renderer2 } from '@angular/core';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements OnInit   {

  constructor(private elementRef: ElementRef, private renderer: Renderer2 ) {

   }

  ngOnInit() {
  }


  ngAfterViewInit() {

    let body: HTMLElement = document.getElementsByClassName('body')[0] as HTMLElement;
    let footer: HTMLElement = document.getElementsByClassName('footer')[0] as HTMLElement;


    footer.style.color='white';
    body.style.background='linear-gradient(to right, #0395ff, #a53398)'

    
}
ngOnDestroy() {

  let body: HTMLElement = document.getElementsByClassName('body')[0] as HTMLElement;
  let footer: HTMLElement = document.getElementsByClassName('footer')[0] as HTMLElement;
  footer.removeAttribute("color");
  footer.setAttribute("color",'rgb(82, 80, 80)');
 
  footer.style.color='rgb(82, 80, 80)';
  body.style.background='white'
  
}
}
