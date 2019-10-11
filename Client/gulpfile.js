var { series, src, dest, watch } = require('gulp');
var concat = require('gulp-concat');
var sass = require('gulp-sass');

sass.compiler = require('node-sass');

function buildStyles(cb) {
  src('./Styles/**/*.scss')
    .pipe(sass().on('error', sass.logError))
    .pipe(concat('main.css'))
    .pipe(dest('./wwwroot/css'));

  cb();
}

function watchStyles(cb) {
  watch('./Styles/**/*.scss', buildStyles);

  cb();
}

exports.default = series(buildStyles, watchStyles);
