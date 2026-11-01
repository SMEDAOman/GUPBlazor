# GUPBlazor — patterns

> GUPBlazor 0.3.4. Compositions built from the components, not components
> themselves. Each one below has **no** dedicated `Gup…` type — do not look for one.

## Error summary

A validation summary that lists every invalid field and links to each one. There is no `GupErrorSummary` component — it is a `GupBanner` with `Type=Error` wrapping a list of buttons, plus `role="alert"` on the wrapper so assistive tech announces it.

Live demo: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/demo/error-summary

<!-- from GUPBlazorDemo/Components/Pages/Demo/ErrorSummary.razor -->
```razor
<GupBanner Type="GupBannerType.Error">
              <TitleContent>There is a problem</TitleContent>
              <ChildContent>
                <p class="form-error-summary__intro">
                  It looks like we're missing a few details. Please provide the following information to continue:
                </p>
                <ul>
                  <li>
                    <button type="button" class="form-error-summary__link">
                      Please enter upload Previous Qualification Certificate (PhD)
                    </button>
                  </li>
                </ul>
              </ChildContent>
            </GupBanner>
```

## Add row

Adding rows to a table from a flyout form, rather than editing in place.

Live demo: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/demo/add-row

<!-- from GUPBlazorDemo/Components/Pages/Demo/Patterns/AddRow.razor -->
```razor
<GupFlyout IsOpen="_open" Heading="Add a partner" OnClose="Close">
      <ChildContent>
      <GupFormList>
        <GupInputField Name="ar-name" Type="text" @bind-Value="_name">Full name</GupInputField>
        <GupInputField Name="ar-role" Type="text" @bind-Value="_role">Role</GupInputField>
        <GupInputField Name="ar-share" Type="text" @bind-Value="_share">
          <ChildContent>Ownership share</ChildContent>
          <Hint>As a percentage, for example 25%.</Hint>
        </GupInputField>
      </GupFormList>
      </ChildContent>
      <FooterContent>
        <GupButtonGroup>
          <GupButton Appearance="GupButtonAppearance.Primary" OnClick="Add">Add partner</GupButton>
          <GupButton Appearance="GupButtonAppearance.Text" OnClick="Close">Cancel</GupButton>
        </GupButtonGroup>
      </FooterContent>
    </GupFlyout>
```

## Address form

The standard address field set, in the order and grouping services use.

Live demo: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/demo/address-form

<!-- from GUPBlazorDemo/Components/Pages/Demo/Patterns/AddressForm.razor -->
```razor
<GupFormSection Heading="Address">
          <GupFormList>
            <GupDropdownField Name="governorate" Placeholder="Select governorate">
              <Label>Governorate</Label>
              <ChildContent>
                <GupDropdownMenu>
                  @foreach (var g in Governorates)
                  {
                    <GupDropdownMenuItem Label="@g" Value="@g.ToLowerInvariant().Replace(' ', '-')" />
                  }
                </GupDropdownMenu>
              </ChildContent>
            </GupDropdownField>

            <GupDropdownField Name="wilayat" Placeholder="Select wilayat">
              <Label>Wilayat</Label>
              <ChildContent>
                <GupDropdownMenu>
                  @foreach (var w in Wilayats)
                  {
                    <GupDropdownMenuItem Label="@w" Value="@w.ToLowerInvariant().Replace(' ', '-')" />
                  }
                </GupDropdownMenu>
              </ChildContent>
            </GupDropdownField>

            <GupInputField Name="area" Type="text">Area</GupInputField>
            <GupInputField Name="way-number" Type="text">Way number</GupInputField>
            <GupInputField Name="house-number" Type="text">House number</GupInputField>

            <GupTextarea Name="additional-directions" Rows="3">
              <ChildContent>Additional directions</ChildContent>
              <HintContent>Landmarks or directions that help a courier find the address.</HintContent>
            </GupTextarea>
          </GupFormList>
        </GupFormSection>
```

---

Full index: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/index.md
