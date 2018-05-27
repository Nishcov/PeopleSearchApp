import { Component, OnInit } from '@angular/core';
import { PersonService } from '../../services/person.service';
import { ToastyService } from 'ng2-toasty';

@Component({
    selector: 'app-person-form',
    templateUrl: './person-form.component.html',
    styleUrls: ['./person-form.component.css']
})
export class PersonFormComponent implements OnInit {
    person: any = {
        address: {},
        interests: []
    };

    constructor(
        private personService: PersonService,
        private toastyService: ToastyService) {
    }

    ngOnInit() {
    }

    submit() {
        this.personService.create(this.person)
            .subscribe(
            x => console.log(x),
            err => {
                this.toastyService.error({
                    title: 'Error',
                    msg: 'An unexpected error has occurred.',
                    theme: 'bootstrap',
                    showClose: true,
                    timeout: 5000
                });
            });
    }
}
