# BookWriter Application
---

This repository hosts the solution for **BookWriter**, an application consisting of two projects that simulate the process of printing a book. Its indended usage is to highlight common development problems like reading and writing from files, string manipulation, and cross-platform implementation of image processing routines.


> **Note:** The code is for demonstration purposes only. It is part of a presentation held at [.NETworking conference 2025](https://dotnetconf.dev.bg/).


## Projects Overview

### 1. ClassLibrary Project
- **Target Framework**: .NET Framework 4.6.2
- **Purpose**: Handles the core logic for rendering book pages.
- **Key Component**: `BookRenderer` class
  - Loads a `.txt` file and splits its content into pages, each containing **24 lines**.
  - Renders each page as a bitmap, representing a visual book page.
  - Main method: `GetPageData(int position)`
    - Accepts a **position pointer** indicating the current position in the text file.
    - Retrieves **24 lines** of text based on the provided position to render the page.

### 2. ConsoleApp Project
- **Target Framework**: .NET Framework 4.6.2
- **Purpose**: Serves as the application's user interface.
- **Functionality**:
  - References the **ClassLibrary Project** to utilize the `BookRenderer` class.
  - Instantiates the `BookRenderer` and calls its `GetPageData` method.
  - **Persistence**:
    - Keeps track of the `position` parameter passed to `GetPageData`.
  - **Book Rendering Process**:
    - Renders the entire book, logging progress to the console after every **100 pages**.
    - Outputs the **total time** needed to render the book.

