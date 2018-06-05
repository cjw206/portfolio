import { Component, OnInit } from '@angular/core';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';
import { AboutModalContent } from './app.aboutmodalcontent';
import { Project } from './../models/project';

@Component ({
    selector: 'app-root',
    templateUrl: '../app.component.html'
})

export class AboutModal {
    bsModalRef: BsModalRef;
    projects: Project;

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