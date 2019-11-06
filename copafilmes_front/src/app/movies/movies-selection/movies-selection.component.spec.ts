import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MoviesSelectionComponent } from './movies-selection.component';

describe('MoviesSelectionComponent', () => {
  let component: MoviesSelectionComponent;
  let fixture: ComponentFixture<MoviesSelectionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MoviesSelectionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MoviesSelectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
