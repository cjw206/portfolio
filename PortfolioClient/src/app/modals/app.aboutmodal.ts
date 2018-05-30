import { Component, OnInit } from '@angular/core';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';
import { AboutModalContent } from './app.aboutmodalcontent';

@Component ({
    selector: 'app-root',
    templateUrl: '../app.component.html'
})

export class AboutModal {
    bsModalRef: BsModalRef;

    constructor(private modalService: BsModalService) {}

    openModal (about: string) {
        const initialState = {
            body: about,
            title: 'About'
        };

        this.bsModalRef = this.modalService.show(AboutModalContent, { initialState });
        this.bsModalRef.content.closeBtnName = 'Close';
    }


}