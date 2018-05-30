import { Component, OnInit } from '@angular/core';
import { PersonService } from '../../services/person.service';
import { ToastyService } from 'ng2-toasty';
import { Router } from '@angular/router';

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
        private toastyService: ToastyService,
        private router: Router) {
    }

    ngOnInit() {
    }

    submit() {
        var result = this.personService.create(this.person);

        result.subscribe(x => {
            this.toastyService.success({
                title: 'Success!',
                msg: 'New person was saved successfully.',
                theme: 'bootstrap',
                showClose: true,
                timeout: 5000
            });
            this.router.navigate(['/people'])
        });
    }
}
