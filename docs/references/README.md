# References

## [XPath Cheatsheet](https://devhints.io/xpath)
## [CSS Cheatsheet](https://devhints.io/css)
## [CSS Diner](http://flukeout.github.io)

## CSS Locator Cheat Sheet

| Approach | Example | Description |
| :--- | :--- | :--- |
| ID | `#example` | `#` denotes an id |
| Class | `.example` | `.` denotes a class name |
| Classes | `.example.success` | use a `.` for each class |
| Direct Child | `div > a` | finds the element in the next child |
| Child | `div a` | finds the element in the next child or child's child |
| Sibling | `input.username + input` | finds the next adjacent sibling |
| Attribute Values | `form input[name='example']` | great alternative for id and class matches, |
| Attribute Values | `input[name='example'][type='button']` | can chain multiple filters together |
| Location | `li:nth-child(4)` | finds the fourth element |
| Location | `li:nth-type-child(4)` | finds the fourth element in a list |
| Location | `*:nth-child(4)` | finds the fourth element regardless of the type |
| Sub-String | `a[id^='beginning']` | finds a match that starts with \(prefix\) |
| Sub-String | `a[id$='end']` | finds a match that starts with \(suffix\) |
| Sub-String | `a[id*='gooey-center']` | finds a match that starts with \(substring\) |
| Inner Text | `a:contains('Log Out')` | an alternative to substring matching |
