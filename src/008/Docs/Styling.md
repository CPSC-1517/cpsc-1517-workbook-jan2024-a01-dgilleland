# Styling

> ![Est. Read Time](https://img.shields.io/badge/Read%20Time-6%20min-brightgreen)
> ![Est. Code Time](https://img.shields.io/badge/Code%20Time-18--30%20min-blue)
> ![Est. Redo Time](https://img.shields.io/badge/Redo%20Time-3%20min-orange)

## Shallow Beginnings

Our empty template does not have a *favicon*; let's provide one by copying the [`favicon.png`](./favicon.png) into the [`wwwroot` folder](../Website/wwwroot/) and adding the following line to the `<head>` of the [`App.razor`] component.

```html
<link rel="icon" type="image/png" href="/favicon.png">
```

We're going to want a few other images for a bit of "bling", so copy the [`Images` folder](./Images/) from this directory into the [`wwwroot` folder](../Website/wwwroot/). Here are some of the key images from this folder that are of interest:

|  |  |  |  |  |
|--|--|--|--|--|
| ![](./Images/icons8-database-32.png) | ![](./Images/icons8-database-96.png) | ![](./Images/icons8-internet-laces-72.png) | ![](./favicon.png) | ![](./Images/icons8-octahedron-32.png)  |
| ![](./Images/icons8-code-folder-32.png) | ![](./Images/icons8-dice-32.png) | ![](./Images/icons8-fidget-spinner-32.png) | ![](./Images/icons8-joker-32.png) | ![](./Images/icons8-knight-32.png) |
| ![](./Images/icons8-lottery-32.png) | ![](./Images/icons8-code-folder-32.png) | ![](./Images/icons8-test-folder-32.png) | ![](./Images/icons8-folder-tree-32.png) |  |


While we're at it, let's also add in a reference to the set of [**Line-Awesome**](https://icons8.com/line-awesome) icons via a CDN (*Content-Delivery Network*) resource. That way, we can throw in a couple of nice icons for buttons/links along our journey.

```html
<link rel= "stylesheet"
      href= "https://maxst.icons8.com/vue-static/landings/line-awesome/line-awesome/1.3.0/css/line-awesome.min.css" >
```

Now it's time to introduce our classless-styling library, [**Pico.css**](https://picocss.com/). Add the following line to the `<head>` of the `App.razor` component.

> ***NOTE:** the portions that read `@@picocss` and `pico@@2` each have an extra `@` because of how Razor pages (the foundation for Blazor) use that as a way of identifying variables; the double `@@` "escapes" so that a single `@` symbol will appear in the rendered HTML.*

```html
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@@picocss/pico@@2/css/pico.min.css">
```

If you also want to use some of the newer features of Pico.css regarding [colors](https://picocss.com/docs/colors#usage-with-css), you can add in the next line as well.

```html
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@@picocss/pico@@2/css/pico.color.min.css">
```

## Prepping our Site Navigation

We'll use a secondary layout component for site navigation. Create a Razor Component file in the [`Layout`](../Website/Components/Layout/) folder and name it `SiteNav.razor`. In that file, add the following HTML.

```html
<nav class="container-fluid">
    <ul>
        <li><img alt="logo" src="/Images/icons8-internet-laces-72.png" /></li>
        <li><strong>Blazor 8</strong></li>
    </ul>
    <ul>
        <li><a href="/"><i class="las la-home"></i> Home</a></li>
        <li><a href="/form-01"><i class="las la-wind"></i> Demo 1</a></li>
        <li><a href="/form-02"><i class="las la-comment-alt"></i> Demo 2</a></li>
        <li>
            <details class="dropdown">
                <summary><i class="las la-chalkboard"></i> Group</summary>
                <ul dir="ltr">
                    <li><a href="/Product/Index"><i class="las la-info"></i> About</a></li>
                    <li><a href="/Product/Edit"><i class="las la-file-contract"></i> Edit Thing</a></li>
                </ul>
            </details>
        </li>
    </ul>
</nav>
```

## Fixing the Main Layout

It's time to have our main layout make use of our site navigation and the Pico.css styling. Open the [`MainLayout.razor` file](../Website/Components/Layout/MainLayout.razor) and replace the line that reads `@Body` with the following code (do not change any of the other code in the layout file).

```razor
<SiteNav />
<main class="container">
    @Body
</main>
<footer class="container" data-theme="dark">
    <hr />
    <ul>
        <li>Based on the Blazor 8 (Empty) template.</li>
        <li>Using the <a href="https://picocss.com/" target="_blank">PicoCSS</a> No-Class Stylesheet.</li>
        <li><a target="_blank" href="https://icons8.com/icon/eTJ3Q9REJ1nH/internet">Internet</a> icon by <a target="_blank" href="https://icons8.com">Icons8</a>.</li>
        <li><a href="https://icons8.com/line-awesome" target="_blank">Line-Awesome Icons</a> used throughout.</li>
    </ul>
    <p>&copy; 2024 - Instructor Dan</p>
</footer>
```

----

## Other Images

| | | | | |
|-|-|-|-|-|
| ![](./Images/html-css-js-icons-11563328364gmstz4ubs9.png) | | | | |
