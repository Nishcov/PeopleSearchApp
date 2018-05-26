import { Component, OnInit } from '@angular/core';
import { PersonService } from '../../services/person.service';

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

    constructor(private personService: PersonService) {
    }

    ngOnInit() {
    }

    submit() {
        this.personService.create(this.person)
            .subscribe(x => console.log(x));
    }
}
