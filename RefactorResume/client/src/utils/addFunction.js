////Component Functionality Functions

//Scroll on overvlow
export function ScrollableComponent({ children }) {
    const containerStyle = {
        overflow: 'auto',
    }
    return (
        <div className="scrollable" style={containerStyle}>
            {children}
        </div>
    );
};