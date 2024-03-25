# Database Update

- Add an optional ID parameter for the page url/route `@page "/Product/Edit/{id:int?}"`
- Associate a property in the Code Block to capture that value (defaults to `0`)
- Get that specific product, if identified
- Link from Product Catalog to Edit form
  - Test that the link works
- create the `UpdateProduct` method in the BLL
- Switch out the Add/Update button text
- Handle the form submit to do either an add or an update
