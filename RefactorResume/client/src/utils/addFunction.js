////Component Functionality Functions

import React, { useRef, useEffect } from 'react';

//Scroll on overvlow
export function ScrollableComponent({ children }) {
    const containerRef = useRef(null);

    useEffect(() => {
        const container = containerRef.current;
        const indicatorClass = 'has-scroll';

        const checkScroll = () => {
            if (container.scrollHeight > container.clientHeight) {
                container.classList.add(indicatorClass);
            } else {
                container.classList.remove(indicatorClass);
            }
        };

        const hideIndicator = () => {
            container.classList.remove(indicatorClass);
        };

        checkScroll();

        window.addEventListener('resize', checkScroll);
        container.addEventListener('scroll', hideIndicator);

        return () => {
            window.removeEventListener('resize', checkScroll);
            container.removeEventListener('scroll', hideIndicator);
        };
    }, []);

    return (
        <div className="scrollable" ref={containerRef}>
            {children}
            <div className="scroll-indicator">Scroll for more details ⬇️</div>
        </div>
    );
}
