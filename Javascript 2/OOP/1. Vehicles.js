var vehicles = (function () {

    var AfterburnerState = Object.freeze({
        "ACTIVATED": 1,
        "DEACTIVATED": 2
    });

    var PropellerSpinDirection = Object.freeze({
        "CLOCKWISE": 1,
        "COUNTERCLOCKWISE": 2
    });

    var TransportMode = Object.freeze({
        "LAND": 1,
        "WATER": 2,
        "AIR": 3
    });

    Function.prototype.inherit = function (parent) {
        this.prototype = new parent();
        this.prototype.constructor = parent;
    };

    Function.prototype.extend = function (parent) {
        for (var i = 1; i < arguments.length; i += 1) {
            var name = arguments[i];
            this.prototype[name] = parent.prototype[name];
        }

        return this;
    }

    function PropulsionUnit() {
    }

    PropulsionUnit.prototype.getAcceleration = function () {
    }

    function Wheel(radius) {
        this.radius = radius;
    }

    Wheel.inherit(PropulsionUnit);

    Wheel.prototype.getAcceleration = function () {
        return parseInt(2 * Math.PI * this.radius);
    }

    function PropellingNozzle(power, afterburnerState) {
        this.power = power;
        this.afterburnerState = afterburnerState;
    }

    PropellingNozzle.inherit(PropulsionUnit);

    PropellingNozzle.prototype.getAcceleration = function () {
        var acceleration = this.power;
        if (this.afterburnerState === AfterburnerState.ACTIVATED) {
            acceleration *= 2;
        }

        return acceleration;
    }

    function Propeller(finsNumber, spinDirection) {
        this.finsNumber = finsNumber;
        this.spinDirection = spinDirection;
    }

    Propeller.inherit(PropulsionUnit);

    Propeller.prototype.getAcceleration = function () {
        var acceleration = this.finsNumber;
        if (this.rotationDirection === RotationDirection.COUNTERCLOCKWISE) {
            acceleration *= -1;
        }

        return acceleration;
    }

    function Vehicle(speed, propulsionUnits) {
        this.speed = speed;
        this.propulsionUnits = propulsionUnits;
    }

    Vehicle.prototype.accelerate = function () {
        for (var i = 0, len = this.propulsionUnits.length; i < len; i++) {
            this.speed += this.propulsionUnits[i].getAcceleration();
        }
    }

    function LandVehicle(speed, wheels) {
        Vehicle.apply(this, arguments);
    }

    LandVehicle.inherit(Vehicle);

    function AirVehicle(speed, propellingNozzles) {
        Vehicle.apply(this, arguments);
    }

    AirVehicle.inherit(Vehicle);

    AirVehicle.prototype.switchAfterburnerState = function (afterburnerState) {
        for (var i = 0, len = this.propulsionUnits.length; i < len; i++) {
            if (this.propulsionUnits[i] instanceof PropellingNozzle) {
                this.propulsionUnits[i].afterburnerState = afterburnerState;
            }
        }
    }

    function WaterVehicle(speed, propellers) {
        Vehicle.apply(this, arguments);
    }

    WaterVehicle.inherit(Vehicle);

    WaterVehicle.prototype.setPropellersSpinDirection = function (spinDirection) {
        for (var i = 0; i < this.propulsionUnits.length; i++) {
            if (this.propulsionUnits[i] instanceof Propeller) {
                this.propulsionUnits[i].spinDirection = spinDirection;
            }
        }
    }

    function AmphibiousVehicle(speed, propellers, wheels, mode) {

        var propulsionUnits = [];
        for (var i = 0; i < propellers.length; i++) {
            propulsionUnits.push(propellers[i]);
        }

        for (var j = 0; j < wheels.length; j++) {
            propulsionUnits.push(wheels[i]);
        }

        Vehicle.call(this, speed, propulsionUnits);
        this.mode = mode;
    }

    AmphibiousVehicle.inherit(Vehicle);
    AmphibiousVehicle.extend(WaterVehicle, "setPropellersSpinDirection");

    AmphibiousVehicle.prototype.accelerate = function () {
        if (this.mode === TransportMode.LAND) {
            for (var i = 0; i < this.propulsionUnits.length; i++) {
                if (this.propulsionUnits[i] instanceof Wheel) {
                    this.speed += this.propulsionUnits[i].getAcceleration();
                }
            }
        } else if (this.mode === TransportMode.WATER) {
            for (var i = 0; i < this.propulsionUnits.length; i++) {
                if (this.propulsionUnits[i] instanceof Propeller) {
                    this.speed += this.propulsionUnits[i].getAcceleration();
                }
            }
        }
    }

    AmphibiousVehicle.prototype.setTransportMode = function (mode) {
        if (mode === TransportMode.LAND || mode === TransportMode.WATER) {
            this.mode = mode;
        }
    }

    return {
        AfterburnerState: AfterburnerState,
        PropellerSpinDirection: PropellerSpinDirection,
        TransportMode: TransportMode,
        Wheel: Wheel,
        PropellingNozzle: PropellingNozzle,
        Propeller: Propeller,
        LandVehicle: LandVehicle,
        AirVehicle: AirVehicle,
        WaterVehicle: WaterVehicle,
        AmphibiousVehicle: AmphibiousVehicle
    };
})();