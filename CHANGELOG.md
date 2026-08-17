# Changelog

## [Unreleased]

- Fix several CSS property emission bugs: `maxHeightMaxContent`/`maxHeightMinContent` now emit `max-height`, `minHeightMaxContent`/`minHeightMinContent` now emit `min-height`, `flexDirectionInitial`/`flexDirectionInheritFromParent` now emit `flex-direction`, `outlineOffset` now emits `outline-offset`, and `justifyItemsStrench`/`justifySelfStrench` now emit the valid CSS value `stretch`
- Add `fontWeight(string)` overload for CSS-variable / keyword string values
- Support letter-spacing

## 1.0.2 - 2025-03-11

- Support flex-self
- Support flex-items
- Support flex-content

## 1.0.1 - 2024-11-14

- Add ILLink.Substitutions.xml for better trimming

## 1.0.0 - 2024-01-31

- Improve flex

## 0.3.2 - 2022-11-12

### Changed

* Use Ionide.KeepAChangelog.Tasks
* Set FSharp.Core to 6.0.0
