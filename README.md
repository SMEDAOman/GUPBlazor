# Blazor GUP Components

This project is an initiative by the SMEs Development Authority (Oman) to develop and maintain a **Blazor implementation of GUP (Government Unified Platform) components**.

It aims to bring standardized, reusable UI components into the .NET ecosystem, enabling consistent and high-quality digital experiences across government and enterprise applications.

The project is inspired by the Angular implementation:  
https://github.com/ekateriinal/gup-components-angular

---

## 📦 Installation

The package is available on NuGet. You can install it using any of the following methods:

**Package Manager Console**

```
Install-Package GUPBlazor
```

**.NET CLI**

```
dotnet add package GUPBlazor
```

**PackageReference** (add to your `.csproj`)

```xml
<PackageReference Include="GUPBlazor" Version="*" />
```

Or browse the package directly at:  
https://www.nuget.org/packages/GUPBlazor

### Adding required styles

In your `App.razor` (or `_Host.cshtml` for Blazor Server), add the `<GUPHTMLHeader/>` component inside `<head>` and the GUP script reference before the closing `</body>` tag:

```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <base href="/" />
    <title>Gov.om Templates</title>


    @* Add GUPBlazor required styles and meta tags *@
    <GUPHTMLHeader/>



    <HeadOutlet />
</head>
<body>
    <Routes />
    <script src="_framework/blazor.web.js"></script>
    <script src="_content/GUPBlazor/gup.js"></script>
</body>
</html>
```

---

## 🎯 Purpose

The goal of this project is to provide a **Blazor-native component library** that aligns with GUP design standards, supporting:

- Government digital services  
- SME platforms  
- Internal enterprise systems  

By adopting these components, teams can ensure **consistency, accessibility, and faster development cycles**.

---

## 🚀 Features

- ✅ Blazor-native implementation of GUP components  
- 🎨 Consistent UI aligned with GUP design system  
- ♿ Accessibility-focused components  
- 🌍 Localization support (including Arabic)  
- 🔧 Extensible and maintainable architecture  

---

## 🧩 Scope

This project focuses on:

- Recreating core components from the Angular version  
- Maintaining design and behavior parity  
- Ensuring responsiveness across devices  
- Supporting RTL layouts and multilingual use cases  

---

## 📦 Getting Started

> ⚠️ This project is currently under active development.

Instructions and usage examples will be added as components become stable.

---

## 🛠️ Project Initiation & Maintenance

This project was **initiated and is actively maintained by Caesar Moussalli** as part of the SMEs Development Authority efforts to modernize and standardize UI development using Blazor.

The initiative aims to:

- Establish a robust Blazor-based alternative to existing GUP implementations  
- Ensure long-term sustainability and continuous improvement of the component library  
- Support internal teams and external partners in building consistent digital solutions  

Ongoing maintenance includes:

- Continuous updates to match GUP standards  
- Performance and accessibility improvements  
- Feature expansion and community contributions  

---

## 🤝 Contributing

Contributions are welcome and encouraged.

You can contribute by:

- Reporting issues  
- Suggesting improvements  
- Submitting pull requests  

Please ensure your contributions align with the overall design and architecture goals of the project.

---

## 📄 License

To be defined.

---

## 📌 Acknowledgment

This project builds upon the concepts and design system introduced in:  
https://github.com/ekateriinal/gup-components-angular
