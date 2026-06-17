# OrderHub Razor Page Triage

This repository contains my response to Question 3 of the OrderHub trial task.

## Overview

The original Razor Page was reviewed and updated with a focus on maintainability, security, and user experience.

The solution keeps the page server-rendered while using vanilla JavaScript to provide live subtotal updates without requiring a page reload.

## Key Issues Identified

### 1. XSS Risk

The original page used:

```cshtml
@Html.Raw(Model.SchoolName)
```

`Html.Raw` bypasses Razor's built-in HTML encoding. Since school names are displayed to administrators, I would rely on Razor's default encoding to reduce the risk of cross-site scripting (XSS).

### 2. Full Page Submission on Quantity Changes

The original implementation submitted the entire form whenever a quantity was changed:

```html
<div onclick="updateQty(@line.Id)">
```

```javascript
document.forms[0].submit();
```

This creates unnecessary server requests and degrades the user experience, especially during peak ordering periods. The updated version recalculates the subtotal in the browser using vanilla JavaScript.

### 3. Brittle Form Binding

The original page generated input names dynamically:

```html
<input name="qty_@line.Id" value="@line.Quantity" />
```

This approach makes validation and maintenance more difficult. The updated version uses strongly typed Razor Page model binding through `asp-for`.

## Improvements

* Removed `Html.Raw`
* Introduced strongly typed Razor binding
* Separated server rendering from client-side interaction
* Added live subtotal updates using vanilla JavaScript
* Eliminated full page reloads when quantities change

## Files

* `ConfirmOrder.cshtml`
* `ConfirmOrder.cshtml.cs`
