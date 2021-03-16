import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})
export class CourseComponent implements OnInit {

  public Courses: Course[];
  public baseurl: string;
  public http: HttpClient;
  public userCourse: UserCourse;

  timeLeft: number = 60;
  interval: any;
  play: boolean;
  count: number = 0;
  percentage: number = 0;

  mapCoursesPercentage = new Map(); //   map javascript dictionary
  mapCoursesWatched = new Map(); // hold the value of the time for each course


  constructor(_http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.baseurl = _baseUrl;
    this.http = _http;
  }

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    console.log(this.baseurl + 'api/course');
    this.http.get<Course[]>(this.baseurl + 'api/course').subscribe(result => {
      this.Courses = result;

      // initilize percentage and "video watched"
      for (var course of this.Courses) {
        this.mapCoursesPercentage.set(course.id, 0);
        this.mapCoursesWatched.set(course.id, 0);
      }

    }, error => console.error(error));
  }

  addCourse(courseId: number) {
    // User Id harcoded = 1
    let userId = 1;

    console.log(courseId);
    this.userCourse = {
      userId :userId,
      courseId : courseId
    };
    console.log(this.userCourse);
    console.log(this.baseurl + 'api/course');
    this.http.post(this.baseurl + 'api/course', this.userCourse).subscribe(result => {
      console.log(result);
    }, error => {
      alert("User/Course Already exists");
    }, () => {
        alert('User/Course Added');
       }
    );
  }


  startPlaying(courseId: number, courseLength: number) {
    // check if course is completed
    if ((this.mapCoursesWatched.get(courseId) * 100 / courseLength) >= 100) {
      return;
    }

    clearInterval(this.interval); // start another timer
    this.count = 0;

    this.interval = setInterval(() => {
      this.count = this.mapCoursesWatched.get(courseId);
      console.log(this.count++);
      this.mapCoursesWatched.set(courseId, this.count++);  //add 1 value to the dictionary
      console.log(this.mapCoursesWatched.get(courseId));

      // calculate percentage
      this.percentage = this.mapCoursesWatched.get(courseId) * 100 / courseLength;
      this.mapCoursesPercentage.set(courseId, this.percentage); //add percetage to the course

      //percentage == 100 it should exit 
      if (this.percentage >= 100) {
        alert('You have completed the course ');
        clearInterval(this.interval); // start another timer
        return;
      }
      console.log(this.count);
    }, 1000)
  }


    stopPlaying() {
      clearInterval(this.interval);
    }

  getPercentageWatched(courseId: number) {
    return this.mapCoursesPercentage.get(courseId) != null ? this.mapCoursesPercentage.get(courseId).toFixed(1).toString() : 0;
  }

}




interface Course {
  id: number;
  description: string;
  length: number;
}

interface UserCourse {
  userId: number;
  courseId: number;
}

