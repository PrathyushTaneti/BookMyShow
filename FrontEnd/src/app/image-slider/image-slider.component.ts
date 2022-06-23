import { Component, ViewChild, OnInit } from '@angular/core';
import { NgbCarousel, NgbSlideEvent, NgbSlideEventSource } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-image-slider',
  templateUrl: './image-slider.component.html'
})
export class SliderComponent implements OnInit {
  public imageOne = "../../assets/images/1.avif";
  public imageTwo = "../../assets/images/2.avif";
  public imageThree = "../../assets/images/3.avif";
  public imageFour = "../../assets/images/4.avif";
  allSliderImages:any[] = [];

  constructor() { }

  ngOnInit(): void {
    this.allSliderImages.push(this.imageFour);
    this.allSliderImages.push(this.imageOne);
    this.allSliderImages.push(this.imageThree);
    this.allSliderImages.push(this.imageTwo);
  }

  paused = false;
  unpauseOnArrow = false;
  pauseOnIndicator = false;
  pauseOnHover = true;
  pauseOnFocus = true;

  @ViewChild('carousel', { static: true })
  carousel!: NgbCarousel;

  togglePaused() {
    if (this.paused) {
      this.carousel.cycle();
    } else {
      this.carousel.pause();
    }
    this.paused = !this.paused;
  }

  onSlide(slideEvent: NgbSlideEvent) {
    if (this.unpauseOnArrow && slideEvent.paused &&
      (slideEvent.source === NgbSlideEventSource.ARROW_LEFT || slideEvent.source === NgbSlideEventSource.ARROW_RIGHT)) {
      this.togglePaused();
    }
    if (this.pauseOnIndicator && !slideEvent.paused && slideEvent.source === NgbSlideEventSource.INDICATOR) {
      this.togglePaused();
    }
  }
}



