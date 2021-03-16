"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.appRoutes = void 0;
var home_component_1 = require("./home/home.component");
var course_component_1 = require("./course/course.component");
exports.appRoutes = [
    { path: '', component: home_component_1.HomeComponent },
    { path: 'home', component: home_component_1.HomeComponent },
    { path: 'Course', component: course_component_1.CourseComponent },
];
//# sourceMappingURL=route.js.map