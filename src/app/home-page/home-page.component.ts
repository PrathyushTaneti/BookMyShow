import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AppService } from '../Services';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-homepage',
  templateUrl: './home-page.component.html'
})
export class HomepageComponent implements OnInit {
  public allMovieDetails!: Observable<any[]>;
  public allPosters: any[] = [];
  public posterOne = "../../assets/posters/1.avif";
  public posterTwo = "../../assets/posters/2.avif";
  public posterThree = "../../assets/posters/3.avif";
  public posterFour = "../../assets/posters/4.avif";
  public posterFive = "../../assets/posters/5.avif";

  constructor(private service:AppService, private router: Router) { }

  ngOnInit(): void {
    this.allMovieDetails = this.service.getAllMovieDetails();
    this.printDetails();
    this.allPosters.push(this.posterOne);
    this.allPosters.push(this.posterTwo);
    this.allPosters.push(this.posterThree);
    this.allPosters.push(this.posterFour);
    this.allPosters.push(this.posterFive);
  }

  printDetails() {
    this.allMovieDetails.forEach(movieDetail => {
      window.console.log(movieDetail);
    })
  }

  selectedMovieDetail(id: number) {  
    this.router.navigate(['view/', id]);
  }

}
