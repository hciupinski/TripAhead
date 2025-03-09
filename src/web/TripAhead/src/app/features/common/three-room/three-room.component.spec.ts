import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ThreeRoomComponent } from './three-room.component';

describe('ThreeRoomComponent', () => {
  let component: ThreeRoomComponent;
  let fixture: ComponentFixture<ThreeRoomComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ThreeRoomComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ThreeRoomComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
