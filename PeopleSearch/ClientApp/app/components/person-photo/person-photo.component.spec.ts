import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonPhotoComponent } from './person-photo.component';

describe('PersonPhotoComponent', () => {
  let component: PersonPhotoComponent;
  let fixture: ComponentFixture<PersonPhotoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PersonPhotoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonPhotoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
