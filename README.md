# Flight Emissions Tracker

An engineering-focused project that integrates real-time air traffic data from the OpenSky Network API to calculate and visualize the carbon footprint of global aviation. This project serves as a technical bridge for my transition into the Data Engineering and Scientific Researce Space (Brain-Computer Interface and Neuroscience, in particular!) focusing on high-performance data pipelines and low-allocation serialization.

## 🚀 The Mission
The goal is to move beyond standard API consumption by implementing high-performance .NET patterns, such as custom `Utf8JsonReader` and `JsonDocument` converters, to handle complex, heterogeneous data structures at scale.

## 🛠 Tech Stack
- **Backend:** .NET 8/10 (C#)
- **Data Ingestion:** OpenSky Network API (REST)
- **Serialization:** System.Text.Json (Custom Converters)
- **Patterns:** DTO Pattern, Separation of Concerns, ETL Pipelines

## 📍 Project Milestones & Roadmap
I am currently building this in phases. This checklist represents the engineering roadmap for the project:

### Phase 1: Data Ingestion & Foundation 🏗️
- [x] **Project Initialization:** Clean Architecture setup with separate Projects for Core, Infrastructure, and API.
- [x] **OpenSky Integration:** Successful connection to the OpenSky Network REST API.
- [x] **High-Performance Serialization:** Implementation of a custom `JsonConverter<T>` using `JsonDocument` to map heterogeneous positional arrays into strongly-typed C# Records.
- [ ] **State Vector Refinement:** Handling edge cases for null/missing telemetry data (e.g., barometric altitude vs. geometric altitude).

### Phase 2: Domain Logic & ETL 🧪
- [x] **Coordinate Math:** Implementing the Haversine formula to calculate flight distances between polling intervals.
- [ ] **Emission Engine:** Building a calculation service based on ICAO carbon emissions parameters (fuel burn per aircraft type).
- [ ] **In-Memory Cache:** Utilizing `IMemoryCache` to reduce API redundant calls and manage stateful flight paths.

## Phase 3: Front-End Visualization
- [] **Implement Map-Based UI:** Implement Map Interface in React where users can navigate to all supported geographical areas
- [] **Add Heat Maps:** Add a "Heat-Map" Layer on top of the Map Interface to quickly indicate CO2 levels of that sector
- [] **Add detailed data section:** Add section where users can see a more detailed breakdown of the CO2 emissions of a particular area


### Phase 3: Scalability & Performance (The "Senior" Layer) ⚡
- [ ] **Async Streaming:** Refactoring the ingestion layer to use `IAsyncEnumerable` for real-time data streaming.
- [ ] **Source Generation:** Moving from reflection-based JSON handling to .NET Source Generators for zero-allocation performance.
- [ ] **Database Persistence:** Implementing an EF Core / PostgreSQL layer to store historical flight data for trend analysis.

### Phase 4: BCI Integration Concepts 🧠
- [ ] **Signal Mapping:** Exploring how flight path "noise" can be visually mapped in a way that mimics EEG signal processing.
- [ ] **Neural Visualization:** Developing a UI (React/Three.js) that visualizes data density, similar to a brain-activity heat map.

## 📈 Engineering Decisions
- **Why Custom Converters?** OpenSky returns mixed-type arrays (strings, ints, and floats in a single list). Instead of using `dynamic`, I chose custom `System.Text.Json` logic to ensure type safety and memory efficiency.
- **Why .NET?** For its high-performance JIT compilation and excellent support for structured data pipelines.

---
*Developed by Mikael - Full-Stack Developer & BCI Enthusiast*
