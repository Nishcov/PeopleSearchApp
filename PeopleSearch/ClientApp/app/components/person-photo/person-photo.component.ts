import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastyService } from 'ng2-toasty';
import { PersonService } from '../../services/person.service';

@Component({
    selector: 'app-person-photo',
    templateUrl: './person-photo.component.html',
    styleUrls: ['./person-photo.component.css']
})
export class PersonPhotoComponent implements OnInit {
    person: any;
    personId: number = 0;

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private toasty: ToastyService,) {

        route.params.subscribe(p => {
            this.personId = +p['id'];
            if (isNaN(this.personId) || this.personId <= 0) {
                router.navigate(['/people']);
                return
            }
        });
    }

    ngOnInit() {
    }
}
