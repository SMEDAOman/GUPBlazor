# GUPBlazor — support types

> GUPBlazor 0.3.4. The public types you construct or receive when using the
> components: event payloads and configuration objects.

A component's parameter table gives the type name; this page gives its members.

## `GupAppliedFilter`

A filter the user has applied, surfaced as a removable chip.

| Member | Type | Default | Description |
|---|---|---|---|
| `Key` | `string` | `""` | Key of the `GupDataTableFilter` this value belongs to. |
| `Value` | `string` | `""` | The applied value. |
| `Label` | `string` | `""` | Text shown on the filter chip. |

## `GupDataTableColumn`

Column definition used to lay out a `GupDataTable`.

| Member | Type | Default | Description |
|---|---|---|---|
| `Key` | `string` | `""` | Unique key identifying the column. |
| `Label` | `string` | `""` | Header text shown for the column. |
| `Width` | `string?` | — | Explicit column width, e.g. "180px" or "20%". Null lets the column size itself. |
| `Grow` | `bool` | — | When true the column absorbs remaining horizontal space. |

## `GupDataTableFilter`

A filter offered in the `GupDataTable` filter panel.

| Member | Type | Default | Description |
|---|---|---|---|
| `Key` | `string` | `""` | Unique key identifying the filter. |
| `Label` | `string` | `""` | Label shown above the filter editor. |
| `Type` | `GupDataTableFilterType` | `GupDataTableFilterType.Text` | Editor kind. Default: `Text`. |
| `Options` | `IReadOnlyList<GupDataTableFilterOption>` | `[]` | Choices offered when `Type` is `Select`. |

## `GupDataTableFilterOption`

A selectable choice for a Select-typed filter.

| Member | Type | Default | Description |
|---|---|---|---|
| `Value` | `string` | `""` | Underlying value submitted when the option is chosen. |
| `Label` | `string` | `""` | Text shown to the user. |

## `GupFileUploadFile`

Metadata for a file selected in a `GupFileUpload`.

| Member | Type | Default | Description |
|---|---|---|---|
| `Name` | `string` | — |  |
| `Size` | `long` | — |  |
| `Type` | `string` | — |  |
| `LastModified` | `long` | — |  |

Positional record — construct it with the members in order:

```csharp
new GupFileUploadFile(name, size, type, lastmodified)
```

## `GupWizardNavArgs`

Passed to wizard navigation handlers, which may redirect the move via `TargetStepIndex` or block it via `Cancel`.

| Member | Type | Default | Description |
|---|---|---|---|
| `CurrentStepIndex` | `int` | — | Index of the step being navigated away from. |
| `TargetStepIndex` | `int` | — | Index the wizard intends to move to. Handlers may overwrite this to redirect navigation. |
| `Cancel` | `bool` | — | Set to true to abort the navigation (e.g. validation failed). |

## `ToastNotification`

A single toast notification raised by `ToastService`.

| Member | Type | Default | Description |
|---|---|---|---|
| `Id` | `Guid` | — |  |
| `Message` | `string` | — |  |
| `Severity` | `string` | — |  |
| `DelayMs` | `int` | — |  |
| `CloseLabel` | `string` | — |  |

Positional record — construct it with the members in order:

```csharp
new ToastNotification(id, message, severity, delayms, closelabel)
```

# Injectable services

Registered by `AddGUPBlazor()`. Inject with `@inject`, in namespace
`GUPBlazor.Services`.

## `ToastService`

Raises toast notifications. Register with `AddGUPBlazor()`, inject where a toast is needed, and place a single `GupToastContainer` in the layout to render them.

```razor
@using GUPBlazor.Services
@inject ToastService Toasts
```

| Member | Description |
|---|---|
| `Action<ToastNotification>? OnShow` | Raised when a toast should be displayed. |
| `Action<Guid>? OnRemove` | Raised when the toast with the given id should be dismissed. |
| `Action? OnClear` | Raised when all toasts should be dismissed. |
| `Guid Show(string message, string severity = "neutral", int delayMs = 5000, string closeLabel = "Close")` | Displays a toast and returns its id, which can be passed to `Remove`. |
| `void Remove(Guid id)` | Dismisses the toast with the given id. |
| `void Clear()` | Dismisses every visible toast. |

# Static helpers

Lookup tables and utilities the library ships, so you do not have to
hardcode your own.

## `GupFlagCountries`

ISO 3166-1 alpha-2 code to English country name, covering every flag bundled under `wwwroot/flags`. Generated from the flag-icons package (MIT).

| Member | Description |
|---|---|
| `IEnumerable<string> Codes` | Every supported ISO 3166-1 alpha-2 code, lower-case and ordered. |
| `string? ResolveCode(string? nameOrCode)` | Resolves a country name or ISO 3166-1 alpha-2 code to its code, or null when unknown. Matching ignores case and surrounding whitespace. |
| `string? GetName(string? code)` | Returns the English country name for a code, or null when unknown. |

---

Full index: /ai/index.md
