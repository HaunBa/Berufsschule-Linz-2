<!doctype html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="Bootstrap seite mit php">
    <meta name="author" content="Danis mum">
    <meta name="generator" content="Hugo 0.88.1">
    <title>PHP Bootstrap example</title>

    <link rel="canonical" href="https://getbootstrap.com/docs/5.1/examples/navbar-fixed/">

    <!-- Bootstrap core CSS -->
<link href="dist/css/bootstrap.min.css" rel="stylesheet">

    <style>
      .bd-placeholder-img {
        font-size: 1.125rem;
        text-anchor: middle;
        -webkit-user-select: none;
        -moz-user-select: none;
        user-select: none;
      }

      @media (min-width: 768px) {
        .bd-placeholder-img-lg {
          font-size: 3.5rem;
        }
      }
    </style>

    
    <!-- Custom styles for this template -->
    <link href="navbar-top-fixed.css" rel="stylesheet">
  </head>
  <body>
    
<nav class="navbar navbar-expand-md navbar-dark fixed-top bg-dark">
  <div class="container-fluid">
    <a class="navbar-brand" href="#">Fixed navbar</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarCollapse" aria-controls="navbarCollapse" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarCollapse">
      <ul class="navbar-nav me-auto mb-2 mb-md-0">
        <li class="nav-item">
          <a class="nav-link" aria-current="page" href="?pages=start">Home</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="?pages=form">Formular</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="?pages=ort">Ort</a>
        </li>
      </ul>
      <form class="d-flex">
        <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search">
        <button class="btn btn-outline-success" type="submit">Search</button>
      </form>
    </div>
  </div>
</nav>

<main class="container">
  <div class="bg-light p-5 rounded">
    <h1>Website</h1>
    <?php
    include 'pages/conf.php';
    if (isset($_GET['pages'])) {
      switch ($_GET['pages']) {
        case 'form':
            include 'pages/plz.php';
          break;
        case 'ort':
            include 'pages/ort.php';
          break;
        default:
            include 'pages/start.html';
          break;
      }
    }else {
      include 'pages/start.html';
    }
    ?>
  </div>
</main>
    <script src="dist/js/bootstrap.bundle.min.js"></script>
  </body>
</html>