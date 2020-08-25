(defblock :name stop-publisher :is-top t
	(executor
		:executor-name stop-publisher
		:verb "stop"
		:description "Stops the publisher."
		:usage-samples (
			"pub stop"))

	(end)
)
