import { Component } from "@angular/core";
import { BsModalRef } from "ngx-bootstrap/modal";

@Component ({
    selector: 'modal-content',
    template: `
    <div class="modal-header">
      <h4 class="modal-title pull-left">{{title}}</h4>
      <button type="button" class="close pull-right" aria-label="Close" (click)="bsModalRef.hide()">
        <span aria-hidden="true">&times;</span>
      </button>
    </div>
    <div class="modal-body">
     <p>{{body}}</p>
    </div>
    <div class="modal-footer">
      <button type="button" class="btn btn-default" (click)="bsModalRef.hide()">{{closeBtnName}}</button>
    </div>
  `
})

export class AboutModalContent {
    body: string;
    closeBtnName: string;
    title: string;

    constructor (public bsModalRef: BsModalRef) {}
}