HOTEL MANAGEMENT APPLICATION

Functionality:
1. Migration to create database and tables for this app.
	- Run package manager console and type this command: update-database.

2. Hotel CRUD:
	- Create. Add new hotel.
		- User inputs: Hotel name, City (dropdown list), Address, Total room, Floors count, Rooms per floor.

	- Update. Update existing hotel data.
		- User inputs: Hotel name, City, Address.

	- Display. Get list of all hotels.
		- User inputs: Select 'All Hotels' from hotels dropdown in navigation bar.

	- Remove. Delete database from database. Soft delete implemented.
		- User inputs: press button to delete hotel.

3. Hotel manager page:
	- List of rooms able for booking.
		- Info displayed:
			- Room name.
			- Input buttons.
		- User inputs:
			- Button - Book. Prompts user to another page. In that page you fill customer details and submit entered data. 
								After submit user is redirected back to hotel page. This room now removed from rooms able 
								for booking list and moved to Booked Rooms list.
			- Button - Close. Redirects user to another page. In that page user adds reason why room is closed and submits data.
								Then user is redirected back to hotel page. Now room is removed from Rooms Able for Booking list
								and moved to Closed Rooms list.

	- List of booked rooms.
		- Info displayed:
			- Room name.
			- Customer N.Surname.
			- Customer requests.
			- Input buttons.
		- User inputs:
			- Button - Free the room. After customer leaves room user marks room as free by pressing this button. Then this room is 
								removed from Booked Rooms list and moved to Needs Cleaning list.

	- List of rooms that needs cleaning:
		- Info displayed:
			- Number of cleaners available.
			- Room name.
			- Cleaner assigned to clean this room.
			- Input buttons.
		- User inputs:
			- Button - Assign cleaner. This button is disabled if room already has assigned cleaner or if there is no cleaners available
								at the moment. If this button active then after pressing it system randomly assigns one cleaner 
								from available cleaners.
			- Button - Room is cleaned. This button is disabled if there is no cleaners assigned. When cleaner cleans room then user can
								mark this room as cleaned. After pressing this button room will be removed from Needs Cleaning list and 
								moved to Rooms for booking list.
			- Button - Close. Redirects user to another page. In that page user adds reason why room is closed and submits data.
								Then user is redirected back to hotel page. Now room is removed from Rooms Need Cleaning list
								and moved to Closed Rooms list.

	- List of closed rooms:
		- Info displayed: 
			- Room name.
			- Reason.
			- Input buttons.
		- User inputs:
			- Button - Open. Pressing this button removes room from closed rooms list and moves it to rooms for booking list. If room isn't 
								cleaned - room is moved to rooms that needs cleaning list.

4. Locations manager.
	- Locations CRUD.
		- Create. Add new country.
			- User inputs:
				- Country name.
				- List of cities.
				- Submit button. Creates country with cities and redirects to all countries page.
		- Update. Update country data.
			- Displayed info:
				- Country name.
				- List of cities.
				- Input buttons.
			- User inputs.
				- Change country name.
				- Change existing cities names.
				-- Adding new cities not implemented.
				- Delete city.
				- Button - Update. Updates location data and redirects back to list of all countries.

5. Employees CRUD.
	- Create. Adds new cleaner to selected hotel.
		- User inputs:
			- First name.
			- Last name.
			- Hotels dropdown.
			- Button - Submit. Creates new cleaner and redirects to all employees page.

	- Display all employees.
		- Data displayed:
			- Name.
			- Hotel name.
			- Hotel address.
			- Action links.
		- User input:
			- Action link - Update. Redirects to update page with user inputs. After submiting new data user is redirected back to list of all employees.
				- First name.
				- Last name.
				- Hotels dropdown.
				- Button - Submit. Creates new cleaner and redirects to all employees page.
			- Action link - Delete. Removes employee.
(POSSIBLE BUG)  -- Functionality to check if cleaner isn't assigned to rooms not implemented. May cause problems with database. Soft delete functionality
				- implemented so data may not be lost if such bug occures.


