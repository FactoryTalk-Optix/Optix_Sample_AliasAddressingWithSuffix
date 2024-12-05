# Indirect aliases addressing using suffixes

When building applications, it is sometimes useful to only pass a single "head" element, and the widget should automatically reference all the relevant items, let's assume we imported some UDTs from the controller:

- `MyMotor`
- `MyMotor_Interlock`
- `MyMotor_Diagnostics`

When a faceplate should be called, and show details for such elements, it is much simpler to just pass "MyMotor" (the head element), and the faceplate should automatically know how to reach the other UDTs to display their values.

This example contains a NetLogic called `FaceplateAliasesLogic` that should be placed in any faceplate where relative addressing is needed, the script will look for the `MainAlias` which is the only argument that should be passed to the faceplate when opening the DialogBox. Additional aliases can be added to the DialogBox with a specific naming convention:

- `Alias_Interlock` will be automatically linked to `MyMotor_Interlock`
- `Alias_Diagnostics` will be automatically linked to `MyMotor_Diagnostics`

The script loops in all aliases of the faceplate, retrieve the `MainAlias` to get the head node, then gets the remaining aliases and searches for the object (in the same tree level of the main object) with the same suffix. If an object with such suffix is not found, an exception is logged.

## Cloning the repository

There are multiple ways to download this project, here is the recommended one

### Clone repository

1. Click on the green `CODE` button in the top right corner
2. Select `HTTPS` and copy the provided URL
3. Open FT Optix IDE
4. Click on `Open` and select the `Remote` tab
5. Paste the URL from step 2
6. Click `Open` button in bottom right corner to start cloning process

## Disclaimer

Rockwell Automation maintains these repositories as a convenience to you and other users. Although Rockwell Automation reserves the right at any time and for any reason to refuse access to edit or remove content from this Repository, you acknowledge and agree to accept sole responsibility and liability for any Repository content posted, transmitted, downloaded, or used by you. Rockwell Automation has no obligation to monitor or update Repository content

The examples provided are to be used as a reference for building your own application and should not be used in production as-is. It is recommended to adapt the example for the purpose, observing the highest safety standards.
