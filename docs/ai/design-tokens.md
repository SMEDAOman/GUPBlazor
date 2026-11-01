# GUPBlazor — design tokens

> GUPBlazor 0.3.4. 266 CSS custom properties, read from the shipped `gup.css`.

Use the token, not the literal value — the palette is re-themed per entity and raw hex
will not follow. Tokens are available anywhere once `<GUPHTMLHeader />` is on the page.

```css
.my-panel {
    color: var(--gup-color-content-high);
    background: var(--gup-color-background-low);
}
```

## Colors — brand

The primary palette. Components consume the semantic slots, not raw hex.

| Token | Value | Note |
|---|---|---|
| `--gup-color-brand-300` | `#ffffff` |  |
| `--gup-color-brand-400` | `#d0e6ff` |  |
| `--gup-color-brand-500` | `#bfd8ff` |  |
| `--gup-color-brand-600` | `#4078ff` |  |
| `--gup-color-brand-700` | `#2f97cd` |  |
| `--gup-color-brand-800` | `#2a3260` |  |
| `--gup-color-brand-900` | `#132450` |  |
| `--gup-color-brand-accent-100` | `#ffffff` |  |
| `--gup-color-brand-accent-200` | `#eceef4` |  |
| `--gup-color-brand-accent-400` | `#36cc8d` |  |
| `--gup-color-brand-accent-600` | `#414e77` |  |
| `--gup-color-brand-accent-700` | `#0a3dac` |  |
| `--gup-color-brand-accent-900` | `#111111` |  |
| `--gup-color-brand-accent-contrast` | `#ffffff` |  |
| `--gup-color-brand-accent-high` | `#2a324c` | accent 700 — deep accent blue |
| `--gup-color-brand-accent-low` | `#c9ccdd` | upstream tokens/src/variables/color.css |
| `--gup-color-brand-accent-medium` | `#414e77` | accent 600 — muted accent |
| `--gup-color-brand-accent-xhigh` | `#11111e` | accent 900 |
| `--gup-color-brand-accent-xlow` | `#eceef4` | accent 200 |
| `--gup-color-brand-contrast` | `#ffffff` |  |
| `--gup-color-brand-high` | `#243d89` | Foundations §2.1 brand-high |
| `--gup-color-brand-low` | `#bfd8ff` |  |
| `--gup-color-brand-medium` | `#2f57cd` | Foundations §2.1 brand-medium (distinct from --primary) |
| `--gup-color-brand-medium-low` | `#4d78ff` | Figma brand 600 |
| `--gup-color-brand-xhigh` | `#132459` | deep navy — header/secondary text, borders (matches mockup) |
| `--gup-color-brand-xlow` | `#dde9ff` |  |

## Colors — content & icon

Text and icon colors, including the inverted set for dark surfaces.

| Token | Value | Note |
|---|---|---|
| `--gup-color-content-info` | `var(--info)` |  |
| `--gup-color-content-inverted-link` | `#bfd8ff` |  |
| `--gup-color-content-inverted-primary` | `#ffffff` |  |
| `--gup-color-content-inverted-secondary` | `rgba(255 255 255 / 70%)` |  |
| `--gup-color-content-inverted-tertiary` | `rgba(255 255 255 / 60%)` |  |
| `--gup-color-content-link` | `#132459` |  |
| `--gup-color-content-negative` | `var(--danger)` |  |
| `--gup-color-content-on-fill` | `#ffffff` |  |
| `--gup-color-content-positive` | `var(--success)` |  |
| `--gup-color-content-primary` | `#27272a` |  |
| `--gup-color-content-secondary` | `#52525b` |  |
| `--gup-color-content-tertiary` | `#7a7a83` |  |
| `--gup-color-content-warning` | `var(--warning)` |  |
| `--gup-color-icon-inverse` | `#ffffff` |  |

## Colors — background & border

Surfaces and strokes. Values with a slash are alpha compositions.

| Token | Value | Note |
|---|---|---|
| `--gup-color-background-accent-container` | `#eceef4` |  |
| `--gup-color-background-base` | `#ffffff` |  |
| `--gup-color-background-canvas` | `#fefcf9` | wizard/form content surface (cream) |
| `--gup-color-background-elevated-container` | `#ffffff` |  |
| `--gup-color-background-footer` | `#1c2133` |  |
| `--gup-color-background-gradient-1-end` | `#f7f5f1` |  |
| `--gup-color-background-gradient-1-start` | `#eff5ff` |  |
| `--gup-color-background-gradient-2-end` | `#fafbff` |  |
| `--gup-color-background-gradient-2-start` | `#eff5ff` |  |
| `--gup-color-background-navigation-bar` | `rgba(255 255 255 / 48%)` |  |
| `--gup-color-background-overcanvas` | `#eceef4` |  |
| `--gup-color-background-page` | `#e8e8e8` | outer page background per Gov.om design system |
| `--gup-color-background-wizard-bar` | `#eceef4` |  |
| `--gup-color-border-inverted-low` | `rgba(255 255 255 / 18%)` |  |
| `--gup-color-border-inverted-medium` | `rgba(255 255 255 / 26%)` |  |
| `--gup-color-border-inverted-xlow` | `rgba(255 255 255 / 12%)` |  |
| `--gup-color-border-low` | `#e1e1e2` |  |
| `--gup-color-border-medium` | `#d0d0d4` |  |
| `--gup-color-border-xlow` | `#f4f4f5` |  |

## Colors — status

Success, warning, error and info slots.

| Token | Value | Note |
|---|---|---|
| `--gup-color-negative-100` | `#ffffff` |  |
| `--gup-color-negative-200` | `#fef5f1` |  |
| `--gup-color-negative-400` | `#f7ada0` |  |
| `--gup-color-negative-600-doc` | `#dc9808` |  |
| `--gup-color-negative-700` | `#ba1c1c` |  |
| `--gup-color-negative-900` | `#b11d1d` |  |
| `--gup-color-negative-contrast` | `#ffffff` |  |
| `--gup-color-negative-high` | `#ba1c1c` |  |
| `--gup-color-negative-low` | `#ffa0a0` |  |
| `--gup-color-negative-medium` | `#dc2828` | live --danger |
| `--gup-color-negative-xhigh` | `#811d1d` |  |
| `--gup-color-negative-xlow` | `#fef1f1` | live red-100 |
| `--gup-color-neutral-100` | `#ffffff` |  |
| `--gup-color-neutral-300` | `#fcfcfc` |  |
| `--gup-color-neutral-600` | `#303034` |  |
| `--gup-color-neutral-700` | `#3f3f40` |  |
| `--gup-color-neutral-800` | `#272726` |  |
| `--gup-color-neutral-900` | `#202024` |  |
| `--gup-color-neutral-contrast` | `#ffffff` |  |
| `--gup-color-neutral-high` | `#27272a` | live gray-800 |
| `--gup-color-neutral-low` | `#d0d0d4` | live gray-400 — disabled bg |
| `--gup-color-neutral-medium` | `#3f3f46` | live gray-700 |
| `--gup-color-neutral-xhigh` | `#202024` | live gray-900 — primary text |
| `--gup-color-neutral-xlow` | `#fcfcfc` | live gray-100 — lightest bg |
| `--gup-color-positive-100` | `#ffffff` |  |
| `--gup-color-positive-200` | `#f2f5f5` |  |
| `--gup-color-positive-400` | `#80efac` |  |
| `--gup-color-positive-600` | `#10a24b` |  |
| `--gup-color-positive-700` | `#1b7f3c` |  |
| `--gup-color-positive-900` | `#134029` |  |
| `--gup-color-positive-contrast` | `#ffffff` |  |
| `--gup-color-positive-high` | `#157f3c` |  |
| `--gup-color-positive-low` | `#85efac` |  |
| `--gup-color-positive-medium` | `#16a249` | live --success |
| `--gup-color-positive-xhigh` | `#114c29` |  |
| `--gup-color-positive-xlow` | `#f2fdf5` | live green-100 |
| `--gup-color-warning-100` | `#ffffff` |  |
| `--gup-color-warning-200` | `#fefce7` |  |
| `--gup-color-warning-400` | `#ffe771` |  |
| `--gup-color-warning-600` | `#cab551` |  |
| `--gup-color-warning-700` | `#a26507` |  |
| `--gup-color-warning-900` | `#733f52` |  |
| `--gup-color-warning-contrast` | `#ffffff` |  |
| `--gup-color-warning-high` | `#a26107` |  |
| `--gup-color-warning-low` | `#ffe771` |  |
| `--gup-color-warning-medium` | `#ca8511` | live --warning |
| `--gup-color-warning-xhigh` | `#733f12` |  |
| `--gup-color-warning-xlow` | `#fefce7` |  |

## Colors — other

Remaining color tokens.

| Token | Value | Note |
|---|---|---|
| `--gup-color-accent-2xhigh` | `#132459` |  |
| `--gup-color-shadow-color-1` | `rgba(28 33 51 / 1%)` |  |
| `--gup-color-shadow-color-2` | `rgba(28 33 51 / 2%)` |  |
| `--gup-color-shadow-color-3` | `rgba(28 33 51 / 3%)` |  |
| `--gup-color-shadow-color-4` | `rgba(28 33 51 / 4%)` |  |
| `--gup-color-shadow-color-5` | `rgba(28 33 51 / 6%)` |  |
| `--gup-color-states-base-bg` | `#ffffff` |  |
| `--gup-color-states-base-bg-control` | `#eceef4` |  |
| `--gup-color-states-base-bg-secondary` | `#f4f4f5` |  |
| `--gup-color-states-base-border` | `#7a7a83` |  |
| `--gup-color-states-base-focus-ring` | `#9747ff` |  |
| `--gup-color-states-disabled-low` | `#d0d0d4` |  |
| `--gup-color-states-disabled-medium` | `#a1a1aa` |  |
| `--gup-color-states-inverted-disabled-low` | `rgba(255 255 255 / 18%)` |  |
| `--gup-color-states-inverted-disabled-medium` | `rgba(255 255 255 / 18%)` |  |
| `--gup-color-states-inverted-primary-active` | `rgba(255 255 255 / 60%)` |  |
| `--gup-color-states-inverted-primary-hover` | `rgba(255 255 255 / 80%)` |  |
| `--gup-color-states-inverted-secondary-active` | `rgba(26 26 26 / 70%)` |  |
| `--gup-color-states-inverted-secondary-hover` | `rgba(26 26 26 / 26%)` |  |
| `--gup-color-states-primary-active` | `rgba(26 26 26 / 70%)` |  |
| `--gup-color-states-primary-hover` | `rgba(26 26 26 / 26%)` |  |
| `--gup-color-states-secondary-active` | `rgba(26 26 26 / 18%)` |  |
| `--gup-color-states-secondary-hover` | `rgba(26 26 26 / 8%)` |  |

## Spacing

The spacing scale. `GupTrack` gap values map onto these.

| Token | Value | Note |
|---|---|---|
| `--gup-space-0` | `0` |  |
| `--gup-space-1` | `2px` |  |
| `--gup-space-2` | `4px` |  |
| `--gup-space-3` | `8px` |  |
| `--gup-space-4` | `12px` |  |
| `--gup-space-5` | `16px` |  |
| `--gup-space-6` | `20px` |  |
| `--gup-space-7` | `24px` |  |
| `--gup-space-8` | `28px` |  |
| `--gup-space-9` | `32px` |  |
| `--gup-space-10` | `36px` |  |
| `--gup-space-11` | `40px` |  |
| `--gup-space-12` | `48px` |  |
| `--gup-space-13` | `64px` |  |
| `--gup-space-14` | `80px` |  |
| `--gup-spacing-between-content` | `24px` |  |
| `--gup-spacing-between-form-fields` | `20px` |  |
| `--gup-spacing-between-items` | `8px` |  |
| `--gup-spacing-between-options` | `0px` |  |
| `--gup-spacing-between-sections` | `48px` |  |
| `--gup-spacing-between-text` | `16px` |  |
| `--gup-spacing-component-default` | `12px` |  |
| `--gup-spacing-content-to-cta` | `32px` |  |
| `--gup-spacing-horizontal-between-columns` | `24px` |  |
| `--gup-spacing-image-bottom` | `8px` |  |
| `--gup-spacing-text-to-component` | `16px` |  |

## Typography

Font families, sizes, weights and line heights.

| Token | Value | Note |
|---|---|---|
| `--gup-font-weight-bold` | `700` | Body (regular) |
| `--gup-font-weight-medium` | `500` |  |
| `--gup-font-weight-regular` | `400` |  |

## Radius & elevation

Corner radii and shadows.

| Token | Value | Note |
|---|---|---|
| `--gup-radius-button` | `999px` |  |
| `--gup-radius-card` | `12px` |  |
| `--gup-radius-component-default` | `8px` |  |
| `--gup-radius-component-full` | `999px` |  |
| `--gup-radius-component-small` | `4px` |  |
| `--gup-shadow-100` | `0 1px 2px 0 var(--gup-color-shadow-color-2),      0 3px 6px 0 var(--gup-color-shadow-color-3)` |  |
| `--gup-shadow-200` | `0 16px 32px 0 var(--gup-color-shadow-color-5),      0 8px 16px 0 var(--gup-color-shadow-color-4),      0 3px 6px 0 var(--gup-color-shadow-color-3),      0 1px 2px 0 var(--gup-color-shadow-color-2)` |  |

## Sizing & layout

Widths, heights, breakpoints and z-index.

| Token | Value | Note |
|---|---|---|
| `--gup-breakpoint-desktop` | `1200px` | nav collapse threshold |
| `--gup-breakpoint-mobile` | `480px` | compact mobile |
| `--gup-breakpoint-mobile-landscape` | `600px` |  |
| `--gup-breakpoint-small-desktop` | `991px` |  |
| `--gup-breakpoint-tablet` | `767px` | sidebar → overlay; single-column |
| `--gup-breakpoint-tablet-landscape` | `810px` |  |
| `--gup-breakpoint-wide` | `1440px` | Container max-widths (Gov.om) |
| `--gup-container-max` | `var(--gup-content-max)` | default page content cap |
| `--gup-container-max-lg` | `960px` |  |
| `--gup-container-max-md` | `720px` |  |
| `--gup-container-max-sm` | `540px` |  |
| `--gup-container-max-xl` | `1248px` |  |

## Everything else

Tokens that do not fall into the groups above.

| Token | Value | Note |
|---|---|---|
| `--gup--is-ltr` | `1` |  |
| `--gup-accordion-item--border-color` | `transparent` |  |
| `--gup-body-lg-size` | `20px` |  |
| `--gup-body-md-size` | `16px` |  |
| `--gup-body-sm-size` | `14px` |  |
| `--gup-body-xl-size` | `24px` |  |
| `--gup-body-xs-size` | `12px` |  |
| `--gup-brand-default` | `#2d2d2d` |  |
| `--gup-brand-secondary` | `#5b5b5b` |  |
| `--gup-brand-soft` | `#f5f5f5` |  |
| `--gup-brand-strong` | `#101010` |  |
| `--gup-callout-color` | `var(--gup-color-content-primary)` |  |
| `--gup-component-0` | `0px` |  |
| `--gup-component-1` | `2px` |  |
| `--gup-component-2` | `4px` |  |
| `--gup-component-3` | `8px` |  |
| `--gup-component-4` | `12px` |  |
| `--gup-component-5` | `16px` |  |
| `--gup-component-6` | `20px` |  |
| `--gup-component-7` | `24px` |  |
| `--gup-component-8` | `32px` |  |
| `--gup-component-9` | `40px` |  |
| `--gup-content-max` | `1024px` |  |
| `--gup-display-md-size` | `clamp(32px, 7vw, 48px)` |  |
| `--gup-divider-border-color` | `var(--gup-color-border-medium)` |  |
| `--gup-divider-gap` | `calc(4 * var(--unit, 4px))` |  |
| `--gup-filter-chip-bg` | `var(--gup-color-states-base-bg-control)` |  |
| `--gup-filter-chip-color` | `var(--gup-color-content-link)` |  |
| `--gup-flag--aspect-ratio` | `4 / 3` |  |
| `--gup-flag--border-radius` | `2px` |  |
| `--gup-grid-columns` | `3` |  |
| `--gup-grid-gap` | `40px` | desktop row/column gap (tablet: 32px) |
| `--gup-gutter` | `32px` |  |
| `--gup-headline-lg-size` | `clamp(24px, 5vw, 32px)` |  |
| `--gup-headline-md-size` | `clamp(22px, 4.5vw, 28px)` |  |
| `--gup-headline-sm-size` | `clamp(20px, 4vw, 24px)` |  |
| `--gup-headline-xl-size` | `clamp(28px, 6vw, 40px)` |  |
| `--gup-headline-xs-size` | `20px` |  |
| `--gup-headline-xxs-size` | `16px` |  |
| `--gup-icon--fill-color` | `var(--gup-color-content-link)` |  |
| `--gup-icon-lg` | `28px` |  |
| `--gup-icon-md` | `24px` |  |
| `--gup-icon-sm` | `20px` |  |
| `--gup-icon-xl` | `32px` |  |
| `--gup-icon-xs` | `16px` |  |
| `--gup-label-lg-size` | `20px` |  |
| `--gup-label-md-size` | `16px` |  |
| `--gup-label-sm-size` | `14px` |  |
| `--gup-label-xl-size` | `24px` |  |
| `--gup-label-xs-size` | `12px` |  |
| `--gup-label-xxs-size` | `10px` |  |
| `--gup-padding-lg` | `32px` |  |
| `--gup-padding-md` | `24px` |  |
| `--gup-padding-sm` | `16px` |  |
| `--gup-padding-xl` | `40px` |  |
| `--gup-padding-xs` | `8px` |  |
| `--gup-page-status--icon-bg` | `var(--gup-color-neutral-low)` |  |
| `--gup-page-status--icon-color` | `var(--gup-color-neutral-medium)` |  |
| `--gup-pagination--color` | `var(--gup-color-brand-xhigh)` |  |
| `--gup-pagination--item-padding` | `8px 20px` | var(--gup-component-2) var(--gup-component-5) |
| `--gup-search--close-width` | `calc(20px + var(--gup-search--controls-gap))` |  |
| `--gup-search--controls-gap` | `10px` |  |
| `--gup-search--search-width` | `calc(24px + var(--gup-search--controls-gap))` |  |
| `--gup-search--second-border-color` | `transparent` |  |
| `--gup-stepper-item--label--color` | `var(--gup-color-content-tertiary)` |  |
| `--gup-stepper-item--selected--label--color` | `var(--gup-color-content-primary)` |  |
| `--gup-stroke-focus-ring` | `6px` |  |
| `--gup-strong-lg-size` | `20px` |  |
| `--gup-strong-md-size` | `16px` |  |
| `--gup-strong-sm-size` | `14px` |  |
| `--gup-strong-xl-size` | `24px` |  |
| `--gup-tab--border-bottom-width` | `var(--gup-component-2)` |  |
| `--gup-toast-bg` | `var(--gup-color-neutral-contrast)` |  |
| `--gup-toast-border` | `var(--gup-color-neutral-low)` |  |
| `--gup-toast-icon-bg` | `var(--gup-color-neutral-medium)` |  |
| `--gup-toggle--knob-size` | `var(--gup-component-6, 20px)` |  |
| `--gup-toggle--padding` | `2px` |  |
| `--gup-toggle--transition-animation` | `cubic-bezier(0.2, 0, 1, 0.9)` |  |
| `--gup-toggle--transition-time` | `70ms` |  |
| `--gup-toggle--width` | `44px` |  |
| `--gup-tooltip--arrow-size` | `var(--gup-component-3)` |  |
| `--gup-tooltip--offset` | `var(--gup-component-2)` |  |
| `--gup-universal-space-4` | `20px` |  |
| `--gup-universal-space-5` | `24px` |  |
| `--gup-universal-space-7` | `40px` |  |
| `--gup-universal-space-9` | `64px` |  |
| `--gup-universal-space-10` | `80px` |  |
| `--gup-wizard-main-max` | `632px` | Grid + gutters (Gov.om): 3-column desktop grid, fluid gap. |

---

Full index: /ai/index.md · Live token browser: /demo/design-tokens
