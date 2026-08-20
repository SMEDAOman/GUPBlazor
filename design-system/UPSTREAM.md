# Upstream snapshot

This folder is a **read-only copy** of the gov.om Angular/Lit design system. It is the
reference the Blazor components in `GUPBlazor/Components` are ported from — nothing here
is compiled or shipped.

| | |
|---|---|
| Source | https://github.com/Gov-om/design-system |
| Commit | `a13478674466e34123bda0c56c46e0562f651b1f` |
| Short SHA | `a134786` |
| Commit date | 2026-08-12 |
| Synced | 2026-08-20 |

## Folder mapping

Upstream nests its sources under `packages/`; they are flattened here:

| Local | Upstream |
|---|---|
| `components/` | `packages/components/src/components/` |
| `stories/` | `packages/components/src/stories/` |
| `styles/` | `packages/components/src/styles/` |
| `types/` | `packages/components/src/types/` |
| `utils/` | `packages/components/src/utils/` |
| `classes/` | `packages/lite-components/src/` |

Note: upstream renamed `classes` to `lite-components` and expanded it from 2 components
to 20+. The local folder name is kept for continuity.

## Refreshing

```
git clone --depth 1 https://github.com/Gov-om/design-system.git
```

Copy the six folders per the mapping above, then update the commit SHA in this file.
Keep the refresh as its own commit so the upstream delta stays separate from Blazor changes.
