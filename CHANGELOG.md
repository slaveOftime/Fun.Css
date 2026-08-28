# Changelog

## [Unreleased]

## 1.1.0 - 2026-08-28

### Added

- Optional `important` flag: `type CssBuilder(?important: bool)`. When `true`, every emitted property is suffixed with ` !important`. Subclasses that override `Run` route the final combine through the new public `ApplyImportant` member to honor the flag. Defaults to `false` (fully backward compatible).
- `(value: string)` overloads for all keyword-only properties (Option 1 consistency pass) — every shorthand/keyword property group now accepts a CSS-variable string alongside its typed unit ops, so `display "var(--display)"` works everywhere, not just on the few groups that already had it.
- Broad standard-CSS coverage (all additive, following the camelCase property + PascalCase keyword + `(string)` overload + `...Initial`/`...InheritFromParent` conventions):
  - Layout: `clear`, `objectFit`/`objectPosition`, `pointerEvents`, `touchAction`, `willChange`, `overscrollBehavior`/`X`/`Y`, `isolation`, `mixBlendMode`, `overflowBlock`/`overflowInline`, `content`, `perspective`/`perspectiveOrigin`, `inset`, `aspectRatio`, `contain`, logical margin/padding longhands, `scrollSnapAlign`/`Type`/`Stop`, `scrollMargin`/`scrollPadding` (+ per-side longhands).
  - Border/outline: `outline` shorthand + `outlineWidth(float)`, border corner radii, `borderImage` shorthand + `borderImageSource`/`Slice`/`Width`/`Outset`/`Repeat`, logical borders (`borderBlock*`/`borderInline*`).
  - Background/mask: `background` shorthand + `backgroundAttachment`/`Origin`/`PositionX`/`Y`, `mask` shorthand + `maskImage`/`Size`/`Repeat`/`Position`/`Clip`/`Origin`/`Composite`.
  - Typography: `font` shorthand, `fontSizeAdjust`, `fontSynthesis`, `fontFeatureSettings`, `fontVariationSettings`, all `fontVariant-*` longhands, `textDecorationThickness`/`SkipInk`, `textAlignLast`, `tabSize`, `overflowWrap`, `textRendering`, `textSizeAdjust`, `textOrientation`, `hyphens`, `wordSpacing`, `lineClamp`, `unicodeBidi`, `colorScheme`, `forcedColorAdjust`.
  - Grid/flex/table/list: `order`, `flexFlow`, `grid` shorthand + `gridAutoRows`/`Columns`/`Flow`, `listStyle` shorthand, `captionSide`, `counterReset`/`Increment`/`Set`, multi-column (`columns`, `columnWidth`/`Count`/`Fill`/`Span`, `columnRule*`).
  - Animation/transition/transform: `animationIterationCount` numeric + string overloads, `transitionBehavior`, `transformBox`, `backfaceVisibility`.
  - Fragmentation/containment: `containIntrinsic*`, `breakBefore`/`After`/`Inside`, `pageBreakBefore`/`After`/`Inside`.
  - `backgroundSize` now has `int`/`float` (px) overloads; `transitionProperty` now has a `string seq` overload joining with `", "`.
- `SKILL.md` — an Agent Skills-format guide for AI coding assistants (and humans) covering the naming/consistency patterns, composition, design-token usage, extension patterns, and gotchas. Referenced from the README.
- Comprehensive unit-test suite covering all public API surfaces (138 tests).

### Changed

- Typo'd/inconsistent operation names kept working but now warn via `[<Obsolete>]` pointing to the corrected spelling (never removed): `justifyItemsStrench`/`justifySelfStrench` → `justifyItemsStretch`/`justifySelfStretch`, `backgroundBlendModeCollorDodge` → `backgroundBlendModeColorDodge`, `wordbreak*` → `wordBreak*`, `tableLayoutFixed'` → `tableLayoutFixed`, `displayInlineElement` → `displayInline`, `positionDefaultStatic` → `positionStatic`, `floatLeft`/`floatRight`/`floatNone` → `floatStyleLeft`/`floatStyleRight`/`floatStyleNone`, `animationDurationCount` → `animationIterationCount(int)`.
- `CssBuilder.fs` reorganized into theme sections (Align, Animation, Background, Border, BoxSpacing, Color, Filter, Flex, Grid, Layout, List, Table, Transform, Transition, Typography) with banner comments; `color`/`font` helper modules moved to `Color.fs`/`Font.fs`. No public API change.

### Fixed

- `transformMatrix` now emits all six `matrix(...)` parameters (previously skipped `y1`).
- `boxShadow` 3-arg overload now emits the `": "` separator.
- `verticalAlignSub` now emits `"sub"` (was `"sup"`).
- `textIndent(int)` now emits `px` (`text-indent: 10px;`).
- `gridTemplateColumns`/`gridTemplateRows` int-seq overloads no longer emit a trailing space.
- `borderWidth` multi-value overloads and `backgroundSize` two-string overload now space-separate values (were comma-separated / emitted `", , "` when an optional arg was omitted).
- `gridTemplateAreas` no longer emits a trailing space.
- Performance: several string-concat paths converted to direct `StringBuilder` appends (`gap`, `transformOrigin`, `gridColumn`/`gridRow`, `borderWidth`, `backgroundSize`).

## 1.0.3 - 2026-08-17

- Add missing `///` doc comments so all `CustomOperation` overloads surface in `Fun.Css.xml` and IDE IntelliSense
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
