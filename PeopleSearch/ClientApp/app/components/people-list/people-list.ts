import { Component, OnInit } from '@angular/core';
import { PersonService } from '../../services/person.service';
import { Person } from '../../models/person';

@Component({
  selector: 'app-people-list',
  templateUrl: './people-list.html',
  styleUrls: ['./people-list.css']
})
export class PeopleListComponent implements OnInit {
    people: Person[] = [];

    constructor(private personService: PersonService) {
        this.people = [];
    }

    ngOnInit() {
        this.personService.getPeople()
            .subscribe(people => this.people = people);
    }
}
