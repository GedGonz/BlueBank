import { Component, OnInit, ElementRef, Renderer2 } from '@angular/core';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements OnInit   {

  constructor(private elementRef: ElementRef, private renderer: Renderer2 ) {
    let body=this.elementRef.nativeElement.ownerDocument.body;
    let footer=this.elementRef.nativeElement.ownerDocument.footer;

    renderer.setStyle(body,'background','linear-gradient(to right, #0395ff, #a53398)');
    //renderer.setStyle(footer,'color','white');
   }

  ngOnInit() {
  }

ngOnDestroy() {
  let body2=this.elementRef.nativeElement.ownerDocument.body;
  let footer2=this.elementRef.nativeElement.ownerDocument.footer;

  this.renderer.setStyle(body2,'background','white');
  //this.renderer.setStyle(footer2,'color','rgb(82, 80, 80)');
  
}
}
