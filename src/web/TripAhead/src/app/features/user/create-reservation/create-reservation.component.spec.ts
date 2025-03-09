import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateReservationComponent } from './create-reservation.component';

describe('CreateReservationComponent', () => {
  let component: CreateReservationComponent;
  let fixture: ComponentFixture<CreateReservationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateReservationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateReservationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
