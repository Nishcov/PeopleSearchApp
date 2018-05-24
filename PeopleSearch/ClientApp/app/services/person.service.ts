import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()

export class PersonService {

    constructor(private http: Http) { }

    getPeople() {
        return this.http.get('/api/people')
            .map(res => res.json());
    }
}
