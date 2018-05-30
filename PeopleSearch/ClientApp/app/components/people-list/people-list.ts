import { Component, OnInit, Inject, NgZone } from '@angular/core';
import { PersonService } from '../../services/person.service';
import { Person } from '../../models/person';
import { ToastyService } from 'ng2-toasty';

@Component({
    selector: 'app-people-list',
    templateUrl: './people-list.html',
    styleUrls: ['./people-list.css']
})
export class PeopleListComponent implements OnInit {
    people: Person[] = [];
    allPeople: Person[] = [];
    search: any = {};

    constructor(
        private personService: PersonService,
        @Inject(NgZone) private ngZone: NgZone,
        @Inject(ToastyService) private toastyService: ToastyService) {
    }

    ngOnInit() {
        this.personService.getPeople()
            .subscribe(people => this.people = this.allPeople = people);
    }

    onSearchSubmit() {
        var people = this.allPeople;

        if (this.search.name) {
            this.ngZone.run(() => {
                // Display wait message while slow search is simulated
                this.toastyService.wait({
                    title: 'Searching...',
                    msg: 'Please wait for matching results.',
                    theme: 'bootstrap',
                    showClose: true,
                    timeout: 5000
                });
            });
            // Simulate slow search by timing out for 5 seconds
            setTimeout(() => {
                // Filter/search by user-provided name
                people = people.filter(p => p.firstName.includes(this.search.name) || p.lastName.includes(this.search.name));
                this.people = people;
            }, 5000);
        }
        else {
            this.people = people;
        }
    }

    onSearchReset() {
        this.ngZone.run(() => {
            // Display wait message while slow search is simulated
            this.toastyService.wait({
                title: 'Resetting...',
                msg: 'Please wait while orginal data is retrieved.',
                theme: 'bootstrap',
                showClose: true,
                timeout: 5000
            });
        });
        // Simulate slow search by timing out for 5 seconds
        setTimeout(() => {
            // Reset and get all people data
            this.search = {};
            this.onSearchSubmit();
        }, 5000);
    }
}
